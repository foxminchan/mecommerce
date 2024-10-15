using Ecommerce.Inventory.Domain.WarehouseAggregate;

namespace Ecommerce.Inventory.Features.Warehouses.List;

internal sealed record ListWarehousesQuery : IQuery<Result<IEnumerable<WarehouseDto>>>;

internal sealed class ListWarehousesHandler(
    IReadRepository<Warehouse> repository,
    ILocationService locationService
) : IQueryHandler<ListWarehousesQuery, Result<IEnumerable<WarehouseDto>>>
{
    public async Task<Result<IEnumerable<WarehouseDto>>> Handle(
        ListWarehousesQuery request,
        CancellationToken cancellationToken
    )
    {
        var warehouses = await repository.ListAsync(cancellationToken);

        var addresses = await warehouses.ToDictionaryAsync(
            warehouse => warehouse.Id,
            warehouse => locationService.GetLocationAsync(warehouse.AddressId, cancellationToken),
            cancellationToken
        );

        return Result.Success(warehouses.ToWarehouseDtos(addresses));
    }
}
