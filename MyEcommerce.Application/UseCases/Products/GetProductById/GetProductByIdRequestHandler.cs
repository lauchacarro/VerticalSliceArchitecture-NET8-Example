using MediatR;

using Microsoft.EntityFrameworkCore;

using MyEcommerce.Application.Data;
using MyEcommerce.Application.Dto;

namespace MyEcommerce.Application.UseCases.Products.GetProductById
{
    public class GetProductByIdRequestHandler : IRequestHandler<GetProductByIdRequest, Result<GetProductByIdResponse>>
    {

        private readonly IMyEcommerceDbContext _context;

        public GetProductByIdRequestHandler(IMyEcommerceDbContext context)
        {
            _context = context;
        }

        public async Task<Result<GetProductByIdResponse>> Handle(GetProductByIdRequest request, CancellationToken cancellationToken)
        {
            var product = await _context.Products.AsNoTracking().Where(x => x.Id == request.Id).FirstOrDefaultAsync(cancellationToken);

            if(product is null)
            {
                return "No existe el producto";
            }


            return new GetProductByIdResponse(product.Id, product.Name, product.Stock, product.CreationDate, product.Status);
            
        }
    }
}
