namespace Ecommerce.Inventory.Features.Stocks;

public sealed record StockDto(
    Guid Id,
    Guid ProductId,
    string? ProductName,
    string? Sku,
    long OnHandQty,
    long ReservedQty,
    long AvailableQty,
    long? WarehouseId,
    long? SupplierId
);
