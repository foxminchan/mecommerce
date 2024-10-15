using Ecommerce.Inventory.Domain.StockAggregate.DomainEvents.Events;

namespace Ecommerce.Inventory.Domain.StockAggregate;

public sealed record StockHistory(Guid Id, long AdjustedQty, bool IsReduced, string? Note)
{
    public static StockHistory Create(StockCreatedEvent @event)
    {
        return new(@event.StockId, @event.Qty, false, "Initial stock");
    }

    public StockHistory Apply(StockUpdatedEvent @event)
    {
        return this with
        {
            AdjustedQty = @event.Qty,
            IsReduced = @event.IsReduce,
            Note = @event.Note,
        };
    }
}
