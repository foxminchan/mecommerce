namespace Ecommerce.Tax.Domain.CategoryAggregate;

public sealed class Category : AuditableEntity<long>, IAggregateRoot
{
    private Category() { }

    public Category(string? name)
        : this()
    {
        Name = Guard.Against.NullOrEmpty(name);
    }

    public string? Name { get; private set; }

    public void UpdateName(string? name)
    {
        Name = Guard.Against.NullOrEmpty(name);
    }
}
