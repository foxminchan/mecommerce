using Ecommerce.Catalog.Domain.VariantAggregate;

namespace Ecommerce.Catalog.Features.Variants.List;

internal sealed class ListVariantsEndpoint
    : IEndpoint<Ok<List<VariantDto>>, ListVariantsQuery, ISender>
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet("/variants", async (ISender sender) => await HandleAsync(new(), sender))
            .ProducesOk<List<VariantDto>>()
            .WithOpenApi()
            .WithTags(nameof(Variant))
            .MapToApiVersion(new(1, 0));
    }

    public async Task<Ok<List<VariantDto>>> HandleAsync(
        ListVariantsQuery request,
        ISender sender,
        CancellationToken cancellationToken = default
    )
    {
        var result = await sender.Send(request, cancellationToken);

        return TypedResults.Ok(result.Value.ToList());
    }
}
