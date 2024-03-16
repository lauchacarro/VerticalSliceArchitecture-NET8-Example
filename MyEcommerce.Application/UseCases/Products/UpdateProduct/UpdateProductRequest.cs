using MediatR;

using MyEcommerce.Application.Dto;

namespace MyEcommerce.Application.UseCases.Products.UpdateProduct
{
    public record UpdateProductRequest(string Name) : IRequest<Result<UpdateProductResponse>>;

}
