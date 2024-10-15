using Ecommerce.Inventory.Domain.StockAggregate.DomainEvents.Events;
using Ecommerce.Inventory.Domain.SupplierAggregate;
using Ecommerce.Inventory.Domain.WarehouseAggregate;
using Ecommerce.Inventory.Domain.WarehouseAggregate.DomainEvents.Events;

namespace Ecommerce.Inventory.Domain.StockAggregate;

public sealed class Stock : AuditableEntity<Guid>, IAggregateRoot, ISoftDelete
{
    private Stock() { }

    public Stock(
        long onHandQty,
        long reservedQty,
        Guid productId,
        long warehouseId,
        long supplierId,
        long productVariantId
    )
        : this()
    {
        OnHandQty = Guard.Against.NegativeOrZero(onHandQty);
        ReservedQty = Guard.Against.NegativeOrZero(reservedQty);
        ProductId = Guard.Against.Default(productId);
        WarehouseId = Guard.Against.Null(warehouseId);
        SupplierId = Guard.Against.Null(supplierId);
        ProductVariantId = Guard.Against.Null(productVariantId);
        RegisterDomainEvent(new StockCreatedEvent(Id, onHandQty));
        RegisterDomainEvent(new WarehouseStatusUpdatedEvent(this));
    }

    public long OnHandQty { get; private set; }
    public long ReservedQty { get; private set; }
    public long ProductVariantId { get; private set; }
    public Guid ProductId { get; private set; }
    public long WarehouseId { get; private set; }
    public Warehouse Warehouse { get; private set; } = default!;
    public long? SupplierId { get; private set; }
    public Supplier? Supplier { get; private set; } = default!;
    public bool IsDeleted { get; set; }

    public void Delete()
    {
        IsDeleted = true;
    }

    public void AddStock(long qty, string? note)
    {
        OnHandQty += Guard.Against.NegativeOrZero(qty);
        RegisterDomainEvent(new StockUpdatedEvent(Id, false, qty, note));
        RegisterDomainEvent(new WarehouseStatusUpdatedEvent(this));
    }

    public void ReserveStock(long qty)
    {
        ReservedQty += Guard.Against.NegativeOrZero(qty);
    }

    public void ReleaseStock(long qty)
    {
        ReservedQty -= Guard.Against.NegativeOrZero(qty);
    }

    public void ReduceStock(long qty, string? note)
    {
        OnHandQty -= Guard.Against.NegativeOrZero(qty);
        RegisterDomainEvent(new StockUpdatedEvent(Id, true, qty, note));
        RegisterDomainEvent(new WarehouseStatusUpdatedEvent(this));
    }

    public void UpdateWarehouse(long warehouseId)
    {
        WarehouseId = Guard.Against.Null(warehouseId);
    }
}
