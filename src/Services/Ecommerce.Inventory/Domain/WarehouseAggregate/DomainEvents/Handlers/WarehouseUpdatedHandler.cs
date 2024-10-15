using Ecommerce.Contracts;
using Ecommerce.Inventory.Domain.WarehouseAggregate.DomainEvents.Events;

namespace Ecommerce.Inventory.Domain.WarehouseAggregate.DomainEvents.Handlers;

internal sealed class WarehouseUpdatedHandler(IPublishEndpoint publishEndpoint)
    : INotificationHandler<WarehouseUpdatedEvent>
{
    public async Task Handle(
        WarehouseUpdatedEvent notification,
        CancellationToken cancellationToken
    )
    {
        var @event = new WarehouseUpdatedIntegrationEvent(
            notification.AddressId,
            notification.Street,
            notification.ZipCode,
            notification.WardOrCommuneId
        );

        await publishEndpoint.Publish(@event, cancellationToken);
    }
}
