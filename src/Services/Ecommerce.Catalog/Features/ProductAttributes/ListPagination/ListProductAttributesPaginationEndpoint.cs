using Ecommerce.Catalog.Domain.ProductAttributeAggregate;

namespace Ecommerce.Catalog.Features.ProductAttributes.ListPagination;

internal sealed class ListProductAttributesPaginationEndpoint
    : IEndpoint<Ok<PagedItems<ProductAttributeDto>>, ListProductAttributesPaginationQuery, ISender>
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet(
                "/product-attributes/by",
                async (ISender sender, [AsParameters] PaginationRequest pagination) =>
                    await HandleAsync(new(pagination), sender)
            )
            .ProducesOk<PagedItems<ProductAttributeDto>>()
            .ProducesValidationProblem()
            .WithOpenApi()
            .WithTags(nameof(ProductAttribute).Humanize(LetterCasing.Title))
            .MapToApiVersion(new(1, 0));
    }

    public async Task<Ok<PagedItems<ProductAttributeDto>>> HandleAsync(
        ListProductAttributesPaginationQuery request,
        ISender sender,
        CancellationToken cancellationToken = default
    )
    {
        var result = await sender.Send(request, cancellationToken);

        var response = new PagedItems<ProductAttributeDto>(result.PagedInfo, result.Value.ToList());

        return TypedResults.Ok(response);
    }
}
