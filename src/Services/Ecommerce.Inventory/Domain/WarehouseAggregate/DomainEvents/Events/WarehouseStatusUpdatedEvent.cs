namespace Ecommerce.Inventory.Domain.WarehouseAggregate.DomainEvents.Events;

public sealed class WarehouseStatusUpdatedEvent(Stock stock) : DomainEvent
{
    public Stock Stock { get; init; } = Guard.Against.Null(stock);
}
