namespace Ecommerce.Inventory.Domain.StockAggregate.Projections;

public sealed record StockHistory(Guid Id, long AdjustedQty, string? Note) { }
