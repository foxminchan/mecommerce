namespace Ecommerce.Contracts;

public sealed class SupplierUpdatedIntegrationEvent(
    Guid addressId,
    string? street,
    string? zipCode,
    long wardOrCommuneId
) : IntegrationEvent
{
    public Guid AddressId { get; init; } = Guard.Against.Default(addressId);
    public string? Street { get; init; } = Guard.Against.NullOrEmpty(street);
    public string? ZipCode { get; init; } = Guard.Against.NullOrEmpty(zipCode);
    public long WardOrCommuneId { get; init; } = Guard.Against.Default(wardOrCommuneId);
}
