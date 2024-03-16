using Microsoft.EntityFrameworkCore;

using MyEcommerce.Domain.Entities;

namespace MyEcommerce.Application.Data
{
    public interface IMyEcommerceDbContext
    {
        DbSet<Product> Products { get; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
