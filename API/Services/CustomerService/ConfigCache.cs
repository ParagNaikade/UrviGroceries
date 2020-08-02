using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts.Domain;
using Contracts.Interfaces;
using DataAccessLayer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;

namespace Business
{
    public class ConfigCache : IConfigCache
    {
        private readonly UrviContext _urviContext;
        private readonly IMemoryCache _memoryCache;

        public ConfigCache(UrviContext urviContext, IMemoryCache memoryCache)
        {
            _urviContext = urviContext;
            _memoryCache = memoryCache;
        }


        public async Task<List<ProductMaster>> GetProductsByBrandAsync(int brandId)
        {
            return await _memoryCache.GetOrCreateAsync($"ProductsByBrand#{brandId}", entry =>
            {
                entry.AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(15);
                return _urviContext.ProductMaster.Where(p => p.BrandId == brandId).ToListAsync();
            });
        }

        public async Task<List<ProductMaster>> GetProductsByCategoryAsync(int categoryId)
        {
            return await _memoryCache.GetOrCreateAsync($"ProductsByCategory#{categoryId}", entry =>
            {
                entry.AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(15);
                return _urviContext.ProductMaster.Where(p => p.CategoryId == categoryId).ToListAsync();
            });
        }

        public async Task<ProductMaster> GetProductByIdAsync(int id)
        {
            return await _memoryCache.GetOrCreateAsync($"ProductById#{id}", entry =>
            {
                entry.AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(15);
                return _urviContext.ProductMaster.FirstOrDefaultAsync(p => p.Id == id);
            });
        }

        public async Task<List<CategoryMaster>> GetAllCategoriesAsync()
        {
            return await _memoryCache.GetOrCreateAsync("AllCategories", entry =>
            {
                entry.AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(15);
                return _urviContext.CategoryMaster.ToListAsync();
            });
        }

        public async Task<List<BrandMaster>> GetAllBrandsAsync()
        {
            return await _memoryCache.GetOrCreateAsync("AllBrands", entry =>
            {
                entry.AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(15);
                return _urviContext.BrandMaster.ToListAsync();
            });
        }
    }
}
