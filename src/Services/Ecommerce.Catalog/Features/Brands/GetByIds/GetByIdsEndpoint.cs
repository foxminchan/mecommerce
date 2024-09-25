using Ecommerce.Catalog.Domain.BrandAggregate;

namespace Ecommerce.Catalog.Features.Brands.GetByIds;

internal sealed class GetByIdsEndpoint : IEndpoint<Ok<List<BrandDto>>, GetByIdsQuery, ISender>
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet(
                "/brands/by",
                async (ISender sender, long[] ids) => await HandleAsync(new(ids), sender)
            )
            .ProducesOk<List<BrandDto>>()
            .ProducesValidationProblem()
            .WithOpenApi()
            .WithTags(nameof(Brand))
            .MapToApiVersion(new(1, 0));
    }

    public async Task<Ok<List<BrandDto>>> HandleAsync(
        GetByIdsQuery request,
        ISender sender,
        CancellationToken cancellationToken = default
    )
    {
        var result = await sender.Send(request, cancellationToken);

        return TypedResults.Ok(result.Value.ToList());
    }
}
