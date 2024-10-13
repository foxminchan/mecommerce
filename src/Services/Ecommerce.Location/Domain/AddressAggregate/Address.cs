using Ecommerce.Location.Domain.WardOrCommuneAggregate;

namespace Ecommerce.Location.Domain.AddressAggregate;

public sealed class Address : AuditableEntity<Guid>, IAggregateRoot
{
    private Address() { }

    public Address(string? street, long wardOrCommuneId)
        : this()
    {
        Street = Guard.Against.NullOrEmpty(street);
        WardOrCommuneId = Guard.Against.NegativeOrZero(wardOrCommuneId);
    }

    public string? Street { get; private set; }
    public long WardOrCommuneId { get; private set; }
    public WardOrCommune WardOrCommune { get; private set; } = default!;

    public void UpdateInformation(string street, long wardOrCommuneId)
    {
        Street = Guard.Against.NullOrEmpty(street);
        WardOrCommuneId = Guard.Against.NegativeOrZero(wardOrCommuneId);
    }
}
