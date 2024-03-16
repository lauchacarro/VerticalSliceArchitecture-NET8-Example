using MediatR;

using MyEcommerce.Application.Dto;

namespace MyEcommerce.Application.UseCases.Products.GetProductById
{
    public record GetProductByIdRequest(int Id) : IRequest<Result<GetProductByIdResponse>>;

}
