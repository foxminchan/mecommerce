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
    public bool IsDeleted { get; set; }
    public ICollection<ContactPerson>? ContactPersons { get; private set; }

    public void Delete()
    {
        IsDeleted = true;
    }

    public void UpdateInformation(string? name, string? email, string phone)
    {
        Name = Guard.Against.NullOrEmpty(name);
        Email = Guard.Against.NullOrEmpty(email);
        Phone = Guard.Against.NullOrEmpty(phone);
    }

    public void UpdateContactPerson(string? name, string? phone, string? email)
    {
        ContactPersons = [new(name, phone, email)];
    }
}
