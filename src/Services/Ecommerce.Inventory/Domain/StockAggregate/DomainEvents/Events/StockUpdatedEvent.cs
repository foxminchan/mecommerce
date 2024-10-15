namespace Ecommerce.Inventory.Domain.StockAggregate.DomainEvents.Events;

public sealed class StockUpdatedEvent(Guid stockId, bool isReduce, long qty, string? note)
    : DomainEvent
{
    public Guid StockId { get; init; } = Guard.Against.Default(stockId);
    public bool IsReduce { get; init; } = isReduce;
    public long Qty { get; init; } = Guard.Against.NegativeOrZero(qty);
    public string? Note { get; init; } = note;
}
