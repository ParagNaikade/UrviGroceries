using Contracts.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer
{
    public class ProductDbContext : DbContext
    {
        public ProductDbContext(DbContextOptions<ProductDbContext> options)
                    : base(options)
        {
        }

        public DbSet<Customer> Customers { get; set; }
    }
}
