namespace Ecommerce.Inventory.Extensions;

internal static partial class InventoryApiTrace
{
    [LoggerMessage(
        EventId = 0,
        Level = LogLevel.Trace,
        Message = "Stock with id {StockId} has been created with quantity {Qty}"
    )]
    public static partial void LogStockCreated(ILogger logger, Guid stockId, long qty);

    [LoggerMessage(
        EventId = 1,
        Level = LogLevel.Trace,
        Message = "Stock with id {StockId} has been updated with quantity {Qty}"
    )]
    public static partial void LogStockUpdated(ILogger logger, Guid stockId, long qty);
}
