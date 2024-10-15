using Ecommerce.Catalog.Domain.ProductAggregate;

namespace Ecommerce.Catalog.Features.Products.GetInfo;

internal sealed class GetProductInfoEndpoint
    : IEndpoint<Results<Ok<ProductInfoDto>, NotFound>, GetProductInfoQuery, ISender>
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet(
                "/products/{id:guid}/info",
                async (Guid id, ISender sender) => await HandleAsync(new(id), sender)
            )
            .ProducesOk<ProductInfoDto>()
            .ProducesNotFound()
            .WithOpenApi()
            .WithTags(nameof(Product))
            .MapToApiVersion(new(1, 0));
    }

    public async Task<Results<Ok<ProductInfoDto>, NotFound>> HandleAsync(
        GetProductInfoQuery request,
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
