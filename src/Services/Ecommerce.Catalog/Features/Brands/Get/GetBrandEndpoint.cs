using Ecommerce.Catalog.Domain.BrandAggregate;

namespace Ecommerce.Catalog.Features.Brands.Get;

internal sealed class GetBrandEndpoint
    : IEndpoint<Results<Ok<BrandDto>, NotFound>, GetBrandQuery, ISender>
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet(
                "/brands/{id:long}",
                async (ISender sender, long id) => await HandleAsync(new(id), sender)
            )
            .ProducesOk<BrandDto>()
            .ProducesNotFound()
            .WithOpenApi()
            .WithTags(nameof(Brand))
            .MapToApiVersion(new(1, 0));
    }

    public async Task<Results<Ok<BrandDto>, NotFound>> HandleAsync(
        GetBrandQuery request,
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
