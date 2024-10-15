using Ecommerce.Inventory.Domain.StockAggregate.DomainEvents.Events;

namespace Ecommerce.Inventory.Domain.StockAggregate.DomainEvents.Handlers;

internal sealed class StockCreatedHandler(
    IDocumentSession documentSession,
    ILogger<StockCreatedHandler> logger
) : INotificationHandler<StockCreatedEvent>
{
    public async Task Handle(StockCreatedEvent notification, CancellationToken cancellationToken)
    {
        InventoryApiTrace.LogStockCreated(logger, notification.StockId, notification.Qty);
        await documentSession.GetAndUpdate<StockHistory>(
            notification.StockId,
            notification,
            cancellationToken
        );
    }
}
