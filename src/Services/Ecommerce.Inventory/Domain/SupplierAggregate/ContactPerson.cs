namespace Ecommerce.Inventory.Domain.SupplierAggregate;

public sealed class ContactPerson : ValueObject
{
    private ContactPerson() { }

    public ContactPerson(string? name, string? phone, string? email)
        : this()
    {
        Name = Guard.Against.NullOrEmpty(name);
        Phone = Guard.Against.NullOrEmpty(phone);
        Email = email;
    }

    public int Id { get; set; }
    public string? Name { get; }
    public string? Phone { get; }
    public string? Email { get; }

    protected override IEnumerable<object?> GetEqualityComponents()
    {
        yield return Name;
        yield return Phone;
        yield return Email;
    }
}
