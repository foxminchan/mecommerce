namespace Ecommerce.Inventory.Domain.SupplierAggregate.DomainEvents.Events;

internal sealed class SupplierDeletedEvent(Guid addressId) : DomainEvent
{
    public Guid AddressId { get; init; } = Guard.Against.Default(addressId);
}
