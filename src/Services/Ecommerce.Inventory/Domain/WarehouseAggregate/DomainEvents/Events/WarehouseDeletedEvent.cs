namespace Ecommerce.Inventory.Domain.WarehouseAggregate.DomainEvents.Events;

public sealed class WarehouseDeletedEvent(Guid addressId) : DomainEvent
{
    public Guid AddressId { get; init; } = Guard.Against.Default(addressId);
}
