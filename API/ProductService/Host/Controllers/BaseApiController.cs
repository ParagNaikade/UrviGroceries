using Contracts.Models.Common;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    public class BaseApiController : ControllerBase
    {
        public IActionResult Ok<T>(T response)
        {
            var reponse = new ApiSuccessResponse<T>(response);
            return base.Ok(reponse);
        }
    }
}
