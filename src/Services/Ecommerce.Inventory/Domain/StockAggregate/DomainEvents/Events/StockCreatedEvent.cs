namespace Ecommerce.Inventory.Domain.StockAggregate.DomainEvents.Events;

public sealed class StockCreatedEvent(Guid stockId, long qty) : DomainEvent
{
    public Guid StockId { get; init; } = Guard.Against.Default(stockId);
    public long Qty { get; init; } = Guard.Against.NegativeOrZero(qty);
}
