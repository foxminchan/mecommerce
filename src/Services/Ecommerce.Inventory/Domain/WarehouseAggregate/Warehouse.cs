using Ecommerce.Inventory.Domain.WarehouseAggregate.DomainEvents.Events;

namespace Ecommerce.Inventory.Domain.WarehouseAggregate;

public sealed class Warehouse : AuditableEntity<long>, IAggregateRoot
{
    private readonly List<Stock> _stocks;

    private Warehouse()
    {
        _stocks = [];
    }

    public Warehouse(string? name, long capacity, Guid addressId)
        : this()
    {
        Name = Guard.Against.NullOrEmpty(name);
        Capacity = Guard.Against.OutOfRange(capacity, nameof(Capacity), 100, long.MaxValue);
        AddressId = Guard.Against.Default(addressId);
        Status = Status.Available;
    }

    public string? Name { get; private set; }
    public long Capacity { get; private set; }
    public Status Status { get; private set; }
    public Guid AddressId { get; }

    public IReadOnlyCollection<Stock> Stocks => _stocks.AsReadOnly();

    public void UpdateInformation(
        string? name,
        long capacity,
        string? street,
        string? zipCode,
        long wardOrCommuneId
    )
    {
        Name = Guard.Against.NullOrEmpty(name);
        Capacity = Guard.Against.NegativeOrZero(capacity);
        SetStatus(_stocks.Sum(s => s.OnHandQty), capacity);
        RegisterDomainEvent(new WarehouseUpdatedEvent(AddressId, street, zipCode, wardOrCommuneId));
    }

    public void Delete()
    {
        RegisterDomainEvent(new WarehouseDeletedEvent(AddressId));
    }

    public void UpdateStockStatus(Stock stock)
    {
        var stocks = _stocks.ToList();
        stocks.Add(stock);
        SetStatus(stocks.Sum(s => s.OnHandQty));
    }

    /// <summary>
    ///     Updates the status of the warehouse based on the total stock compared to its capacity.
    /// </summary>
    /// <param name="totalStock">
    ///     The total stock in the warehouse.
    /// </param>
    /// <param name="capacity">
    ///     The maximum storage capacity of the warehouse. If not provided, the capacity of the warehouse is used.
    /// </param>
    /// <remarks>
    ///     The method evaluates the total stock in the warehouse and sets the status as follows:
    ///     - If the total stock exceeds or equals 100% of the capacity, the warehouse is marked as Full.
    ///     - If the total stock is between 80% and 100% of the capacity, the warehouse is marked as AlmostFull.
    ///     - If the total stock is below 80% of the capacity, the warehouse is marked as Available.
    /// </remarks>
    private void SetStatus(long totalStock, long? capacity = null)
    {
        capacity ??= Capacity;

        if (totalStock >= capacity)
        {
            Status = Status.Full;
        }
        else if (totalStock >= 0.8 * capacity)
        {
            Status = Status.Full;
        }
        else
        {
            Status = Status.Available;
        }
    }
}
