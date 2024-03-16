using MyEcommerce.Domain.Enums;

namespace MyEcommerce.Application.UseCases.Products.GetProductById
{
    public record GetProductByIdResponse(int Id, string Name, int Stock, DateTime CreationDate, ProductStatus Status);
}