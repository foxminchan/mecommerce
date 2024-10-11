using Ecommerce.Catalog.Domain.ProductAggregate;
using Ecommerce.Catalog.Domain.ProductAggregate.Specifications;

namespace Ecommerce.Catalog.Features.Products.List;

internal sealed class ListProductsEndpoint
    : IEndpoint<Ok<PagedItems<ProductListDto>>, ListProductsQuery, ISender>
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet(
                "/products",
                async (ISender sender, [AsParameters] ListProductsRequest request) =>
                    await HandleAsync(new(request), sender)
            )
            .ProducesOk<PagedItems<ProductListDto>>()
            .ProducesValidationProblem()
            .WithOpenApi()
            .WithTags(nameof(Product))
            .MapToApiVersion(new(1, 0));
    }

    public async Task<Ok<PagedItems<ProductListDto>>> HandleAsync(
        ListProductsQuery request,
        ISender sender,
        CancellationToken cancellationToken = default
    )
    {
        var result = await sender.Send(request, cancellationToken);

        var response = new PagedItems<ProductListDto>(result.PagedInfo, result.Value.ToList());

        return TypedResults.Ok(response);
    }
}
