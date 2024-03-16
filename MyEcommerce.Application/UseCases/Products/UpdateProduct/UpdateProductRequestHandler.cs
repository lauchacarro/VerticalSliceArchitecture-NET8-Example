using MediatR;

using MyEcommerce.Application.Dto;

namespace MyEcommerce.Application.UseCases.Products.UpdateProduct
{
    public class UpdateProductRequestHandler : IRequestHandler<UpdateProductRequest, Result<UpdateProductResponse>>
    {

        public UpdateProductRequestHandler()
        {
        }

        public async Task<Result<UpdateProductResponse>> Handle(UpdateProductRequest request, CancellationToken cancellationToken)
        {
            return new UpdateProductResponse(request.Name);
        }
    }
}
