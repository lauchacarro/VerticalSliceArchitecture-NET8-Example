using MediatR;

using MyEcommerce.Application.Dto;

namespace MyEcommerce.Application.UseCases.Products.CreateProduct
{
    public record CreateProductRequest(string Name, int Stock) : IRequest<Result<CreateProductResponse>>;
}
