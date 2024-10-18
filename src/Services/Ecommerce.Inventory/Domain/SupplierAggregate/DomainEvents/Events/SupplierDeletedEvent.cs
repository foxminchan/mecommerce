using Event = Ecommerce.SharedKernel.Model.Event;

namespace Ecommerce.Inventory.Domain.SupplierAggregate.DomainEvents.Events;

internal sealed class SupplierDeletedEvent(Guid addressId) : Event
{
    public Guid AddressId { get; init; } = Guard.Against.Default(addressId);
}
