namespace Ecommerce.Contracts;

public sealed class SupplierDeletedIntegrationEvent(Guid addressId) : IntegrationEvent
{
    public Guid AddressId { get; init; } = Guard.Against.Default(addressId);
}
