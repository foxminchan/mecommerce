using Ecommerce.Inventory.Domain.WarehouseAggregate;

namespace Ecommerce.Inventory.Features.Warehouses.List;

internal sealed class ListWarehousesEndpoint
    : IEndpoint<Ok<List<WarehouseDto>>, ListWarehousesQuery, ISender>
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet("/warehouses", async (ISender sender) => await HandleAsync(new(), sender))
            .ProducesOk<List<WarehouseDto>>()
            .WithOpenApi()
            .WithTags(nameof(Warehouse))
            .MapToApiVersion(new(1, 0));
    }

    public async Task<Ok<List<WarehouseDto>>> HandleAsync(
        ListWarehousesQuery request,
        ISender sender,
        CancellationToken cancellationToken = default
    )
    {
        var result = await sender.Send(request, cancellationToken);

        return TypedResults.Ok(result.Value.ToList());
    }
}
