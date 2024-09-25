using Ecommerce.Catalog.Domain.VariantAggregate;

namespace Ecommerce.Catalog.Features.Variants.ListPagination;

internal sealed class ListVariantsPaginationEndpoint
    : IEndpoint<Ok<PagedItems<VariantDto>>, ListVariantsPaginationQuery, ISender>
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet(
                "/variants/by",
                async (ISender sender, [AsParameters] PaginationRequest pagination) =>
                    await HandleAsync(new(pagination), sender)
            )
            .ProducesOk<PagedItems<VariantDto>>()
            .ProducesValidationProblem()
            .WithOpenApi()
            .WithTags(nameof(Variant))
            .MapToApiVersion(new(1, 0));
    }

    public async Task<Ok<PagedItems<VariantDto>>> HandleAsync(
        ListVariantsPaginationQuery request,
        ISender sender,
        CancellationToken cancellationToken = default
    )
    {
        var result = await sender.Send(request, cancellationToken);

        var response = new PagedItems<VariantDto>(result.PagedInfo, result.Value.ToList());

        return TypedResults.Ok(response);
    }
}
