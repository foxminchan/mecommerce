using Ecommerce.Location.Domain.WardOrCommuneAggregate;

namespace Ecommerce.Location.Domain.AddressAggregate;

public sealed class Address : AuditableEntity<Guid>, IAggregateRoot
{
    private Address() { }

    public Address(string? street, string? zipCode, long wardOrCommuneId)
        : this()
    {
        Street = Guard.Against.NullOrEmpty(street);
        ZipCode = Guard.Against.NullOrEmpty(zipCode);
        WardOrCommuneId = Guard.Against.NegativeOrZero(wardOrCommuneId);
    }

    public string? Street { get; private set; }
    public string? ZipCode { get; private set; }
    public long WardOrCommuneId { get; private set; }
    public WardOrCommune WardOrCommune { get; private set; } = default!;

    public void UpdateInformation(string? street, string? zipCode, long wardOrCommuneId)
    {
        Street = Guard.Against.NullOrEmpty(street);
        ZipCode = Guard.Against.NullOrEmpty(zipCode);
        WardOrCommuneId = Guard.Against.NegativeOrZero(wardOrCommuneId);
    }
}
