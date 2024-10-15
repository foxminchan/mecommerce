using Ecommerce.Inventory.Domain.WarehouseAggregate;

namespace Ecommerce.Inventory.Features.Warehouses;

public static class EntityToDto
{
    public static WarehouseDto ToWarehouseDto(this Warehouse warehouse, GetAddressResponse? address)
    {
        return new(
            warehouse.Id,
            warehouse.Name,
            warehouse.Capacity,
            warehouse.Status,
            address?.Street,
            address?.ZipCode,
            address?.WardOrCommune,
            address?.District,
            address?.StateOrProvince,
            address?.Country,
            address?.Continent
        );
    }

    public static IEnumerable<WarehouseDto> ToWarehouseDtos(
        this IEnumerable<Warehouse> warehouses,
        Dictionary<long, GetAddressResponse?> addresses
    )
    {
        return warehouses
            .Select(warehouse =>
            {
                var address = addresses
                    .Where(x => x.Key == warehouse.Id)
                    .Select(x => x.Value)
                    .FirstOrDefault();

                return warehouse.ToWarehouseDto(address);
            })
            .ToList();
    }
}
