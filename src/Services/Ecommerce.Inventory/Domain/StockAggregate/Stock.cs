using Ecommerce.Inventory.Domain.SupplierAggregate;
using Ecommerce.Inventory.Domain.WarehouseAggregate;

namespace Ecommerce.Inventory.Domain.StockAggregate;

public sealed class Stock : AuditableEntity<Guid>, IAggregateRoot, ISoftDelete
{
    private Stock() { }

    public Stock(
        long onHandQty,
        long reservedQty,
        Guid productId,
        long warehouseId,
        long supplierId
    )
        : this()
    {
        OnHandQty = Guard.Against.NegativeOrZero(onHandQty);
        ReservedQty = Guard.Against.NegativeOrZero(reservedQty);
        ProductId = Guard.Against.Default(productId);
        WarehouseId = Guard.Against.Null(warehouseId);
        SupplierId = Guard.Against.Null(supplierId);
    }

    public long OnHandQty { get; private set; }
    public long ReservedQty { get; private set; }
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

    public void AddStock(long qty)
    {
        OnHandQty += Guard.Against.NegativeOrZero(qty);
    }

    public void ReserveStock(long qty)
    {
        ReservedQty += Guard.Against.NegativeOrZero(qty);
    }

    public void ReleaseStock(long qty)
    {
        ReservedQty -= Guard.Against.NegativeOrZero(qty);
    }

    public void ReduceStock(long qty)
    {
        OnHandQty -= Guard.Against.NegativeOrZero(qty);
        ReservedQty -= Guard.Against.NegativeOrZero(qty);
    }

    public void UpdateWarehouse(long warehouseId)
    {
        WarehouseId = Guard.Against.Null(warehouseId);
    }
}
