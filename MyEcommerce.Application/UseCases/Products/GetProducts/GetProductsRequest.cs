using MediatR;

using MyEcommerce.Application.Dto;

namespace MyEcommerce.Application.UseCases.Products.GetProducts
{
    public record GetProductsRequest(string? Search, int? Take, int? Skip) : IRequest<Result<GetProductsResponse>>;

}
