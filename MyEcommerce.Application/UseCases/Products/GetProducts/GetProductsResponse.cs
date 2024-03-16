using MyEcommerce.Application.Dto;

namespace MyEcommerce.Application.UseCases.Products.GetProducts
{
    public record GetProductsResponse(IEnumerable<ProductDto> Products);
}