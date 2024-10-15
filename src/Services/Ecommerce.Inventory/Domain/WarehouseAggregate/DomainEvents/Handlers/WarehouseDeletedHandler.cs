using Ecommerce.Contracts;
using Ecommerce.Inventory.Domain.WarehouseAggregate.DomainEvents.Events;

namespace Ecommerce.Inventory.Domain.WarehouseAggregate.DomainEvents.Handlers;

internal sealed class WarehouseDeletedHandler(IPublishEndpoint publishEndpoint)
    : INotificationHandler<WarehouseDeletedEvent>
{
    public async Task Handle(
        WarehouseDeletedEvent notification,
        CancellationToken cancellationToken
    )
    {
        var @event = new WarehouseDeletedIntegrationEvent(notification.AddressId);

        await publishEndpoint.Publish(@event, cancellationToken);
    }
}
