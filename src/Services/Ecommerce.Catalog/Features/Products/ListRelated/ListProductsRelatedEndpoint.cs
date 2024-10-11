using Ecommerce.Catalog.Domain.ProductAggregate;

namespace Ecommerce.Catalog.Features.Products.ListRelated;

internal sealed class ListProductsRelatedEndpoint
    : IEndpoint<Ok<PagedItems<ProductListDto>>, ListProductsRelatedQuery, ISender>
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet(
                "/products/{id:guid}/related",
                async (ISender sender, Guid id, [AsParameters] PaginationRequest request) =>
                    await HandleAsync(new(id, request), sender)
            )
            .ProducesOk<PagedItems<ProductListDto>>()
            .ProducesValidationProblem()
            .WithOpenApi()
            .WithTags(nameof(Product))
            .MapToApiVersion(new(1, 0));
    }

    public async Task<Ok<PagedItems<ProductListDto>>> HandleAsync(
        ListProductsRelatedQuery request,
        ISender sender,
        CancellationToken cancellationToken = default
    )
    {
        var result = await sender.Send(request, cancellationToken);

        var response = new PagedItems<ProductListDto>(result.PagedInfo, result.Value.ToList());

        return TypedResults.Ok(response);
    }
}
