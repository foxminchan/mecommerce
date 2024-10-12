using Ecommerce.Inventory.Domain.StockAggregate;

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
    public Guid AddressId { get; private set; }

    public IReadOnlyCollection<Stock> Stocks => _stocks.AsReadOnly();

    public void UpdateInformation(string name, long capacity)
    {
        Name = Guard.Against.NullOrEmpty(name);
        Capacity = Guard.Against.NegativeOrZero(capacity);
    }

    public void MarkAlmostFull()
    {
        Status = Status.AlmostFull;
    }

    public void MarkFull()
    {
        Status = Status.Full;
    }

    public void MarkInactive()
    {
        Status = Status.Inactive;
    }
}
