using Ecommerce.Inventory.Domain.SupplierAggregate.DomainEvents.Events;

namespace Ecommerce.Inventory.Domain.SupplierAggregate;

public sealed class Supplier : AuditableEntity<long>, IAggregateRoot
{
    private Supplier() { }

    public Supplier(
        string? name,
        string? email,
        string? phone,
        List<ContactPerson>? contactPersons,
        Guid addressId
    )
        : this()
    {
        Name = Guard.Against.NullOrEmpty(name);
        Email = Guard.Against.NullOrEmpty(email);
        Phone = Guard.Against.NullOrEmpty(phone);
        AddressId = Guard.Against.Default(addressId);

        if (contactPersons is not null && contactPersons.Count != 0)
        {
            ContactPersons = contactPersons;
        }
    }

    public string? Name { get; private set; }
    public string? Email { get; private set; }
    public string? Phone { get; private set; }
    public Guid AddressId { get; private set; }
    public ICollection<ContactPerson>? ContactPersons { get; private set; }

    public void Delete()
    {
        RegisterDomainEvent(new SupplierDeletedEvent(AddressId));
    }

    public void UpdateInformation(
        string? name,
        string? email,
        string? phone,
        string? street,
        string? zipCode,
        long wardOrCommuneId
    )
    {
        Name = Guard.Against.NullOrEmpty(name);
        Email = Guard.Against.NullOrEmpty(email);
        Phone = Guard.Against.NullOrEmpty(phone);
        RegisterDomainEvent(new SupplierUpdatedEvent(AddressId, street, zipCode, wardOrCommuneId));
    }

    public void UpdateContactPersons(List<ContactPerson> contactPersons)
    {
        ContactPersons = contactPersons;
    }
}
