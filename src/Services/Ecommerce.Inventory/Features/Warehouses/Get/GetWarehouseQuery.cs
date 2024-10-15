using Ecommerce.Inventory.Domain.WarehouseAggregate;

namespace Ecommerce.Inventory.Features.Warehouses.Get;

internal sealed record GetWarehouseQuery(long Id) : IQuery<Result<WarehouseDto>>;

internal sealed class GetWarehouseQueryHandler(
    IReadRepository<Warehouse> repository,
    ILocationService locationService
) : IQueryHandler<GetWarehouseQuery, Result<WarehouseDto>>
{
    public async Task<Result<WarehouseDto>> Handle(
        GetWarehouseQuery request,
        CancellationToken cancellationToken
    )
    {
        var warehouse = await repository.GetByIdAsync(request.Id, cancellationToken);

        if (warehouse is null)
        {
            return Result.NotFound();
        }

        var address = await locationService.GetLocationAsync(
            warehouse.AddressId,
            cancellationToken
        );

        return warehouse.ToWarehouseDto(address);
    }
}
