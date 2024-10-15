using Ecommerce.Contracts;
using Ecommerce.Inventory.Domain.SupplierAggregate.DomainEvents.Events;

namespace Ecommerce.Inventory.Domain.SupplierAggregate.DomainEvents.Handlers;

internal sealed class SupplierUpdatedHandler(IPublishEndpoint publishEndpoint)
    : INotificationHandler<SupplierUpdatedEvent>
{
    public async Task Handle(SupplierUpdatedEvent notification, CancellationToken cancellationToken)
    {
        var @event = new SupplierUpdatedIntegrationEvent(
            notification.AddressId,
            notification.Street,
            notification.ZipCode,
            notification.WardOrCommuneId
        );

        await publishEndpoint.Publish(@event, cancellationToken);
    }
}
