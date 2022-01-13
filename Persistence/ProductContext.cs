using Domain.Model;
using Microsoft.EntityFrameworkCore;

namespace Persistence
{
    public class ProductContext : DbContext
    {
        public ProductContext(DbContextOptions<ProductContext> options) : base(options) { }

        public DbSet<Product>? Products { set; get;}
    }
}