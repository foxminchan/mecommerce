using Ecommerce.Catalog.Domain.ProductAttributeAggregate;

namespace Ecommerce.Catalog.Features.ProductAttributes.Get;

internal sealed class GetProductAttributeEndpoint
    : IEndpoint<Ok<ProductAttributeDto>, GetProductAttributeQuery, ISender>
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet(
                "/product-attributes/{id:long}",
                async (long id, ISender sender) => await HandleAsync(new(id), sender)
            )
            .ProducesOk<ProductAttributeDto>()
            .ProducesNotFound()
            .WithOpenApi()
            .WithTags(nameof(ProductAttribute).Humanize(LetterCasing.Title))
            .MapToApiVersion(new(1, 0));
    }

    public async Task<Ok<ProductAttributeDto>> HandleAsync(
        GetProductAttributeQuery request,
        ISender sender,
        CancellationToken cancellationToken = default
    )
    {
        var result = await sender.Send(request, cancellationToken);

        return TypedResults.Ok(result.Value);
    }
}
