using MediatR;

using MyEcommerce.Application.Data;
using MyEcommerce.Application.Dto;
using MyEcommerce.Domain.Entities;
using MyEcommerce.Domain.Enums;

namespace MyEcommerce.Application.UseCases.Products.CreateProduct
{
    internal class CreateProductRequestHandler : IRequestHandler<CreateProductRequest, Result<CreateProductResponse>>
    {
        private readonly IMyEcommerceDbContext _context;

        public CreateProductRequestHandler(IMyEcommerceDbContext context)
        {
            _context = context;
        }

        public async Task<Result<CreateProductResponse>> Handle(CreateProductRequest request, CancellationToken cancellationToken)
        {

            if (string.IsNullOrWhiteSpace(request.Name))
            {
                return "El nombre es Requerido";
            }


            if (request.Stock <= 0)
            {
                return "El Stock debe ser mayor a cero.";
            }


            Product product = new(request.Name, request.Stock, DateTime.Now, ProductStatus.Active);

            // Agrego el Product a la DB con EntityFrameworkCore

            //_context.Products.Add(product);
            //await _context.SaveChangesAsync(cancellationToken);


            CreateProductResponse result = new(product.Id, product.Name, product.Stock);

            return result;

        }
    }
}
