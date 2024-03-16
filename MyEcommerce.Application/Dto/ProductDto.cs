using MyEcommerce.Domain.Enums;

namespace MyEcommerce.Application.Dto
{
    public record ProductDto(int Id, string Name, int Stock, DateTime CreationDate, ProductStatus Status);
}
