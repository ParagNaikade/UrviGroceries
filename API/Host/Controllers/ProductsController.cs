using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Contracts.Domain;
using Contracts.Interfaces;
using Contracts.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Authentication;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ProductsController : ControllerBase
    {
        private readonly IConfigCache _configCache;

        public ProductsController(IConfigCache configCache)
        {
            _configCache = configCache;
        }
        
        [HttpGet("brand")]
        public async Task<IActionResult> GetProductsByBrandAsync([FromQuery]int brandId)
        {
            return Ok(await _configCache.GetProductsByBrandAsync(brandId).ConfigureAwait(false));
        }

        [HttpGet("category")]
        public async Task<IActionResult> GetProductsByCategoryAsync([FromQuery]int categoryId)
        {
            return Ok(await _configCache.GetProductsByCategoryAsync(categoryId).ConfigureAwait(false));
        }

        [HttpGet]
        public async Task<IActionResult> GetProductByIdAsync([FromQuery]int id)
        {
            return Ok(await _configCache.GetProductByIdAsync(id).ConfigureAwait(false));
        }

        [HttpGet("categories")]
        public async Task<IActionResult> GetAllCategoriesAsync()
        {
            return Ok(await _configCache.GetAllCategoriesAsync().ConfigureAwait(false));
        }

        [HttpGet("brands")]
        public async Task<IActionResult> GetAllBrandsAsync()
        {
            return Ok(await _configCache.GetAllBrandsAsync().ConfigureAwait(false));
        }
    }
}