using Ecommerce.Catalog.Domain.ProductAggregate;

namespace Ecommerce.Catalog.Features.Products.GetDetail;

internal sealed class GetProductDetailEndpoint
    : IEndpoint<Results<Ok<ProductDetailDto>, NotFound>, GetProductDetailQuery, ISender>
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet(
                "/products/{id:guid}",
                async (Guid id, ISender sender) => await HandleAsync(new(id), sender)
            )
            .ProducesOk<ProductDetailDto>()
            .ProducesNotFound()
            .WithOpenApi()
            .WithTags(nameof(Product))
            .MapToApiVersion(new(1, 0));
    }

    public async Task<Results<Ok<ProductDetailDto>, NotFound>> HandleAsync(
        GetProductDetailQuery request,
        ISender sender,
        CancellationToken cancellationToken = default
    )
    {
        var result = await sender.Send(request, cancellationToken);

        return result.Status == ResultStatus.NotFound
            ? TypedResults.NotFound()
            : TypedResults.Ok(result.Value);
    }
}
