﻿using System;
using System.Net;
using System.Threading.Tasks;
using Contracts.Exceptions;
using Contracts.Models.Common;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace WebApi.Middlewares
{
    public class ErrorHandlingMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            HttpStatusCode code;
            ApiErrorResponse apiResponse = new ApiErrorResponse();

            if (exception is ApiException apiException)
            {
                code = (HttpStatusCode)apiException.HttpStatusCode;
                apiResponse.Message = apiException.Message;
            }
            else
            {
                code = HttpStatusCode.InternalServerError;
                apiResponse.Message = exception.Message;
            }

            var jsonSerializerSettings = new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            };

            string result = JsonConvert.SerializeObject(apiResponse, jsonSerializerSettings);
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)code;
            return context.Response.WriteAsync(result);
        }
    }
}
