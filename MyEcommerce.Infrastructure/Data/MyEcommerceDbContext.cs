using Microsoft.EntityFrameworkCore;

using MyEcommerce.Application.Data;
using MyEcommerce.Domain.Entities;

namespace MyEcommerce.Infrastructure.Data
{
    public class MyEcommerceDbContext : DbContext, IMyEcommerceDbContext
    {
        public MyEcommerceDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Product> Products => Set<Product>();
    }
}
