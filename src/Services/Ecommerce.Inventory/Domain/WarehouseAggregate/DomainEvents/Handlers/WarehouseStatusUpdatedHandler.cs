using Ecommerce.Inventory.Domain.WarehouseAggregate.DomainEvents.Events;

namespace Ecommerce.Inventory.Domain.WarehouseAggregate.DomainEvents.Handlers;

internal sealed class WarehouseStatusUpdatedHandler(IRepository<Warehouse> repository)
    : INotificationHandler<WarehouseStatusUpdatedEvent>
{
    public async Task Handle(
        WarehouseStatusUpdatedEvent notification,
        CancellationToken cancellationToken
    )
    {
        var warehouse = await repository.GetByIdAsync(
            notification.Stock.WarehouseId,
            cancellationToken
        );

        warehouse?.UpdateStockStatus(notification.Stock);

        await repository.SaveChangesAsync(cancellationToken);
    }
}
