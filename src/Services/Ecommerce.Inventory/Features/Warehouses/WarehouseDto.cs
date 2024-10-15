using Ecommerce.Inventory.Domain.WarehouseAggregate;

namespace Ecommerce.Inventory.Features.Warehouses;

public sealed record WarehouseDto(
    long Id,
    string? Name,
    long Capacity,
    Status Status,
    string? Street,
    string? ZipCode,
    string? WardOrCommune,
    string? District,
    string? StateOrProvince,
    string? Country,
    string? Continent
);
