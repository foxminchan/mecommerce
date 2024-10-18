using Ecommerce.Contracts;
using Ecommerce.Inventory.Domain.SupplierAggregate.DomainEvents.Events;

namespace Ecommerce.Inventory.Domain.SupplierAggregate.DomainEvents.Handlers;

internal sealed class SupplierDeletedHandler(IPublishEndpoint publishEndpoint)
    : INotificationHandler<SupplierDeletedEvent>
{
    public async Task Handle(SupplierDeletedEvent notification, CancellationToken cancellationToken)
    {
        var @event = new SupplierDeletedIntegrationEvent(notification.AddressId);

        await publishEndpoint.Publish(@event, cancellationToken);
    }
}
