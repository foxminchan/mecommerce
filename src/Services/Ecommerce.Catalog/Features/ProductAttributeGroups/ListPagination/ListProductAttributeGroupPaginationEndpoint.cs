using Ecommerce.Catalog.Domain.ProductAttributeGroupAggregate;

namespace Ecommerce.Catalog.Features.ProductAttributeGroups.ListPagination;

internal sealed class ListProductAttributeGroupPaginationEndpoint
    : IEndpoint<
        Ok<PagedItems<ProductAttributeGroupDto>>,
        ListProductAttributeGroupPaginationQuery,
        ISender
    >
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet(
                "/product-attribute-groups/by",
                async (ISender sender, [AsParameters] PaginationRequest pagination) =>
                    await HandleAsync(new(pagination), sender)
            )
            .ProducesOk<PagedItems<ProductAttributeGroupDto>>()
            .ProducesValidationProblem()
            .WithOpenApi()
            .WithTags(nameof(ProductAttributeGroup).Humanize(LetterCasing.Title))
            .MapToApiVersion(new(1, 0));
    }

    public async Task<Ok<PagedItems<ProductAttributeGroupDto>>> HandleAsync(
        ListProductAttributeGroupPaginationQuery request,
        ISender sender,
        CancellationToken cancellationToken = default
    )
    {
        var result = await sender.Send(request, cancellationToken);

        var response = new PagedItems<ProductAttributeGroupDto>(
            result.PagedInfo,
            result.Value.ToList()
        );

        return TypedResults.Ok(response);
    }
}
