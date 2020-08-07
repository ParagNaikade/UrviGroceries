using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Contracts.Domain;
using Contracts.Interfaces;
using Contracts.Models;
using DataAccessLayer;
using Microsoft.EntityFrameworkCore;

namespace Business
{
    public class OrdersBusiness : IOrdersBusiness
    {
        private readonly OrdersContext _ordersContext;
        private readonly ProductsContext _productsContext;
        private readonly IConfigCache _configCache;

        private readonly string _loggedInUser;

        public OrdersBusiness(OrdersContext ordersContext, ProductsContext productsContext, IUserService userService, IConfigCache configCache)
        {
            _ordersContext = ordersContext;
            _productsContext = productsContext;
            _configCache = configCache;

            _loggedInUser = userService.GetLoggedInUser().Email;
        }

        public async Task<int> AddToCartAsync(ProductDto product)
        {
            await ValidateProductAsync(product).ConfigureAwait(false);

            var cart = new Cart()
            {
                Email = _loggedInUser,
                CreateDate = DateTime.Now,
                ProductId = product.Id,
                Quantity = product.Quantity
            };

            await _ordersContext.Cart.AddAsync(cart).ConfigureAwait(false);

            await _ordersContext.SaveChangesAsync().ConfigureAwait(false);

            return cart.Id;
        }

        public async Task DeleteFromCartAsync(int cartId)
        {
            var itemToRemove = await _ordersContext.Cart.FirstOrDefaultAsync(c => c.Id == cartId && c.Email == _loggedInUser)
                .ConfigureAwait(false);

            if (itemToRemove == null)
            {
                throw new Exception($"Cart item with id {cartId} not found.");
            }

            _ordersContext.Cart.RemoveRange(itemToRemove);

            await _ordersContext.SaveChangesAsync().ConfigureAwait(false);
        }

        public async Task<List<CartDto>> GetCartAsync()
        {
            var cartDtos = new List<CartDto>();

            var cartItems = await _ordersContext.Cart.Where(c => c.Email == _loggedInUser)
                .ToListAsync().ConfigureAwait(false);

            foreach (var cartItem in cartItems)
            {
                var productMaster = await _configCache.GetProductByIdAsync(cartItem.ProductId).ConfigureAwait(false);

                var dto = new CartDto()
                {
                    Id = cartItem.Id,
                    ProductName = productMaster.Name,
                    Quantity = cartItem.Quantity,
                    Size = productMaster.Size
                };

                cartDtos.Add(dto);
            }

            return cartDtos;
        }

        private async Task ValidateProductAsync(ProductDto product)
        {
            if (product == null)
            {
                throw new ArgumentNullException(nameof(product));
            }

            var productMaster = await GetProductMasterAsync(product.Id).ConfigureAwait(false);

            if (productMaster == null)
            {
                throw new Exception($"Product {product.Id} does not exist.");
            }

            if (productMaster.Quantity < product.Quantity)
            {
                throw new Exception($"The quantity exceeded the limit. You can order up-to {productMaster.Quantity}.");
            }
        }

        private async Task<ProductMaster> GetProductMasterAsync(int id)
        {
            var productMaster = await _productsContext.ProductMaster.FirstOrDefaultAsync(
                p => p.Id == id).ConfigureAwait(false);

            return productMaster;
        }
    }
}
