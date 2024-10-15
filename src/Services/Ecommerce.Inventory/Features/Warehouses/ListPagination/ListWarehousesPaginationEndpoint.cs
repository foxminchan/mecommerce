using Ecommerce.Inventory.Domain.WarehouseAggregate;

namespace Ecommerce.Inventory.Features.Warehouses.ListPagination;

internal sealed class ListWarehousesPaginationEndpoint
    : IEndpoint<Ok<PagedItems<WarehouseDto>>, ListWarehousesPaginationQuery, ISender>
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet(
                "/warehouses/by",
                async ([AsParameters] PaginationWithSearchRequest request, ISender sender) =>
                    await HandleAsync(new(request), sender)
            )
            .ProducesOk<PagedItems<WarehouseDto>>()
            .ProducesValidationProblem()
            .WithOpenApi()
            .WithTags(nameof(Warehouse))
            .MapToApiVersion(new(1, 0));
    }

    public async Task<Ok<PagedItems<WarehouseDto>>> HandleAsync(
        ListWarehousesPaginationQuery request,
        ISender sender,
        CancellationToken cancellationToken = default
    )
    {
        var result = await sender.Send(request, cancellationToken);

        var response = new PagedItems<WarehouseDto>(result.PagedInfo, result.Value.ToList());

        return TypedResults.Ok(response);
    }
}
