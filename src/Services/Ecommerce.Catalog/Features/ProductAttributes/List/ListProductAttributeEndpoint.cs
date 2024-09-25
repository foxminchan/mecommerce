using Ecommerce.Catalog.Domain.ProductAttributeAggregate;

namespace Ecommerce.Catalog.Features.ProductAttributes.List;

internal sealed class ListProductAttributeEndpoint
    : IEndpoint<Ok<List<ProductAttributeDto>>, ListProductAttributeQuery, ISender>
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet(
                "/product-attributes",
                async (ISender sender) => await HandleAsync(new(), sender)
            )
            .ProducesOk<List<ProductAttributeDto>>()
            .WithOpenApi()
            .WithTags(nameof(ProductAttribute).Humanize(LetterCasing.Title))
            .MapToApiVersion(new(1, 0));
    }

    public async Task<Ok<List<ProductAttributeDto>>> HandleAsync(
        ListProductAttributeQuery request,
        ISender sender,
        CancellationToken cancellationToken = default
    )
    {
        var result = await sender.Send(request, cancellationToken);

        return TypedResults.Ok(result.Value.ToList());
    }
}
