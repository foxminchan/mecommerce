using Ecommerce.Inventory.Domain.StockAggregate.DomainEvents.Events;

namespace Ecommerce.Inventory.Domain.StockAggregate.DomainEvents.Handlers;

internal sealed class StockUpdatedHandler(
    IDocumentSession documentSession,
    ILogger<StockUpdatedHandler> logger
) : INotificationHandler<StockUpdatedEvent>
{
    public async Task Handle(StockUpdatedEvent notification, CancellationToken cancellationToken)
    {
        InventoryApiTrace.LogStockUpdated(logger, notification.StockId, notification.Qty);
        await documentSession.GetAndUpdate<StockHistory>(
            notification.StockId,
            notification,
            cancellationToken
        );
    }
}
