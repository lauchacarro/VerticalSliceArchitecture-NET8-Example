using MediatR;

using Microsoft.EntityFrameworkCore;

using MyEcommerce.Application.Data;
using MyEcommerce.Application.Dto;

using System.Linq;

namespace MyEcommerce.Application.UseCases.Products.GetProducts
{
    public class GetProductsRequestHandler : IRequestHandler<GetProductsRequest, Result<GetProductsResponse>>
    {
        private readonly IMyEcommerceDbContext _context;

        public GetProductsRequestHandler(IMyEcommerceDbContext context)
        {
            _context = context;
        }
  
        public async Task<Result<GetProductsResponse>> Handle(GetProductsRequest request, CancellationToken cancellationToken)
        {
            var query = _context.Products.AsNoTracking();

            if (!string.IsNullOrWhiteSpace(request.Search))
            {
                query = query.Where(x => x.Name.ToLower().Contains(request.Search.ToLower()));
            }

            if (request.Take.HasValue)
            {
                query = query.Take(request.Take.Value);
            }

            if (request.Skip.HasValue)
            {
                query = query.Take(request.Skip.Value);
            }

            var products = await query.ToListAsync(cancellationToken);

            var productsDtoList = products.Select(x => new ProductDto(x.Id, x.Name, x.Stock, x.CreationDate, x.Status));

            return new GetProductsResponse(productsDtoList);
        }
    }
}
