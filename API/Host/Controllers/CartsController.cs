using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Contracts.Domain;
using Contracts.Interfaces;
using Contracts.Models;
using DataAccessLayer;
using WebApi.Authentication;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CartsController : ControllerBase
    {
        private readonly IOrdersBusiness _ordersBusiness;

        public CartsController(IOrdersBusiness ordersBusiness)
        {
            _ordersBusiness = ordersBusiness;
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddToCartAsync([FromBody] ProductDto product)
        {
            var cartId = await _ordersBusiness.AddToCartAsync(product).ConfigureAwait(false);

            return Ok(cartId);
        }

        [HttpDelete("remove/{cartId}")]
        public async Task<IActionResult> DeleteFromCartAsync(int cartId)
        {
            await _ordersBusiness.DeleteFromCartAsync(cartId).ConfigureAwait(false);

            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> GetCartAsync()
        {
            var cart = await _ordersBusiness.GetCartAsync().ConfigureAwait(false);

            return Ok(cart);
        }
    }
}
