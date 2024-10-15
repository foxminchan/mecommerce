namespace Ecommerce.Contracts;

public sealed class WarehouseDeletedIntegrationEvent(Guid addressId) : IntegrationEvent
{
    public Guid AddressId { get; init; } = Guard.Against.Default(addressId);
}
