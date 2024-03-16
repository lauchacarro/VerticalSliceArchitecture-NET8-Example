using MediatR;

using MyEcommerce.Application.UseCases.Products.CreateProduct;
using MyEcommerce.Application.UseCases.Products.GetProductById;
using MyEcommerce.Application.UseCases.Products.GetProducts;

namespace MyEcommerce.Api.Routes
{

    public static class ProductRoutes
    {
        const string PATH = "/Products";

        public static IEndpointRouteBuilder MapProducts(this IEndpointRouteBuilder endpoint)
        {
            endpoint.MapPost(PATH, async (IMediator mediator, CreateProductRequest request)
                => await mediator.Send(request).ToHttpResult());


            //Estos parametros se reciben desde QueryParams
            endpoint.MapGet(PATH, async (string? search, int? take, int? skip, IMediator mediator)
                => await mediator.Send(new GetProductsRequest(search, take, skip)).ToHttpResult());



            //Este parametro se recibe desde la URL
            endpoint.MapGet(PATH + "/{id}", async (int id, IMediator mediator)
                => await mediator.Send(new GetProductByIdRequest(id)).ToHttpResult());


            return endpoint;
        }
    }

}
