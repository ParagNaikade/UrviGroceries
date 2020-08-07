using System.Collections.Generic;
using System.Threading.Tasks;
using Contracts.Models;

namespace Contracts.Interfaces
{
    public interface IOrdersBusiness
    {
        Task<int> AddToCartAsync(ProductDto product);

        Task DeleteFromCartAsync(int cartId);

        Task<List<CartDto>> GetCartAsync();
    }
}