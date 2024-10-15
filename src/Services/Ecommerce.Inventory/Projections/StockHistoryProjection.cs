using Ecommerce.Inventory.Domain.StockAggregate.DomainEvents.Events;

namespace Ecommerce.Inventory.Projections;

public sealed record StockHistoryDocument(Guid Id, long Qty, bool IsReduce);

public sealed class StockHistoryProjection : MultiStreamProjection<StockHistoryDocument, Guid>
{
    public StockHistoryProjection()
    {
        Identity<StockCreatedEvent>(e => e.StockId);
        Identity<StockUpdatedEvent>(e => e.StockId);
    }

    public StockHistoryDocument Apply(StockHistoryDocument query, StockCreatedEvent @event)
    {
        return query with { Qty = @event.Qty, IsReduce = false };
    }

    public StockHistoryDocument Apply(StockHistoryDocument query, StockUpdatedEvent @event)
    {
        return query with { Qty = @event.Qty, IsReduce = @event.IsReduce };
    }
}
