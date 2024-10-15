using Ecommerce.Inventory.Domain.SupplierAggregate;

namespace Ecommerce.Inventory.Features.Suppliers.List;

internal sealed class ListSupplierEndpoint
    : IEndpoint<Ok<PagedItems<SupplierDto>>, ListSupplierQuery, ISender>
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet(
                "/suppliers",
                async ([AsParameters] PaginationWithSearchRequest request, ISender sender) =>
                    await HandleAsync(new(request), sender)
            )
            .ProducesOk<PagedItems<SupplierDto>>()
            .ProducesValidationProblem()
            .WithOpenApi()
            .WithTags(nameof(Supplier))
            .MapToApiVersion(new(1, 0));
    }

    public async Task<Ok<PagedItems<SupplierDto>>> HandleAsync(
        ListSupplierQuery request,
        ISender sender,
        CancellationToken cancellationToken = default
    )
    {
        var result = await sender.Send(request, cancellationToken);

        var response = new PagedItems<SupplierDto>(result.PagedInfo, result.Value.ToList());

        return TypedResults.Ok(response);
    }
}
