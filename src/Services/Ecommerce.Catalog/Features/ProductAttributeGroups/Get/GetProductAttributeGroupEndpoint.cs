using Ecommerce.Catalog.Domain.ProductAttributeGroupAggregate;

namespace Ecommerce.Catalog.Features.ProductAttributeGroups.Get;

internal sealed class GetProductAttributeGroupEndpoint
    : IEndpoint<
        Results<Ok<ProductAttributeGroupDto>, NotFound>,
        GetProductAttributeGroupQuery,
        ISender
    >
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet(
                "/product-attribute-groups/{id:long}",
                async (long id, ISender sender) => await HandleAsync(new(id), sender)
            )
            .Produces<Ok<ProductAttributeGroupDto>>()
            .ProducesNotFound()
            .WithOpenApi()
            .WithTags(nameof(ProductAttributeGroup).Humanize(LetterCasing.Title))
            .MapToApiVersion(new(1, 0));
    }

    public async Task<Results<Ok<ProductAttributeGroupDto>, NotFound>> HandleAsync(
        GetProductAttributeGroupQuery request,
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
