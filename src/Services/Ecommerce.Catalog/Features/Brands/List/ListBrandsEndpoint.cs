using Ecommerce.Catalog.Domain.BrandAggregate;

namespace Ecommerce.Catalog.Features.Brands.List;

internal sealed class ListBrandsEndpoint
    : IEndpoint<Ok<PagedItems<BrandDto>>, ListBrandsQuery, ISender>
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet(
                "/brands",
                async (ISender sender, [AsParameters] PaginationWithSearchRequest pagination) =>
                    await HandleAsync(new(pagination), sender)
            )
            .ProducesOk<PagedItems<BrandDto>>()
            .ProducesValidationProblem()
            .WithOpenApi()
            .WithTags(nameof(Brand))
            .MapToApiVersion(new(1, 0));
    }

    public async Task<Ok<PagedItems<BrandDto>>> HandleAsync(
        ListBrandsQuery request,
        ISender sender,
        CancellationToken cancellationToken = default
    )
    {
        var result = await sender.Send(request, cancellationToken);

        var response = new PagedItems<BrandDto>(result.PagedInfo, result.Value.ToList());

        return TypedResults.Ok(response);
    }
}
