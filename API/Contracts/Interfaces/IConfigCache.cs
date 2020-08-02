using System.Collections.Generic;
using System.Threading.Tasks;
using Contracts.Domain;

namespace Contracts.Interfaces
{
    public interface IConfigCache
    {
        Task<List<ProductMaster>> GetProductsByBrandAsync(int brandId);

        Task<List<ProductMaster>> GetProductsByCategoryAsync(int categoryId);

        Task<ProductMaster> GetProductByIdAsync(int id);

        Task<List<CategoryMaster>> GetAllCategoriesAsync();

        Task<List<BrandMaster>> GetAllBrandsAsync();
    }
}