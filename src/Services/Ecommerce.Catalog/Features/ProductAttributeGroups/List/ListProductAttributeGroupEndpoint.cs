using Ecommerce.Catalog.Domain.ProductAttributeGroupAggregate;

namespace Ecommerce.Catalog.Features.ProductAttributeGroups.List;

internal sealed class ListProductAttributeGroupEndpoint
    : IEndpoint<Ok<List<ProductAttributeGroupDto>>, ListProductAttributeGroupQuery, ISender>
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet(
                "/product-attribute-groups",
                async (ISender sender) => await HandleAsync(new(), sender)
            )
            .ProducesOk<List<ProductAttributeGroupDto>>()
            .WithOpenApi()
            .WithTags(nameof(ProductAttributeGroup).Humanize(LetterCasing.Title))
            .MapToApiVersion(new(1, 0));
    }

    public async Task<Ok<List<ProductAttributeGroupDto>>> HandleAsync(
        ListProductAttributeGroupQuery request,
        ISender sender,
        CancellationToken cancellationToken = default
    )
    {
        var result = await sender.Send(request, cancellationToken);

        return TypedResults.Ok(result.Value.ToList());
    }
}
