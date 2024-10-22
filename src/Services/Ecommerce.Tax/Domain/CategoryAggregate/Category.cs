namespace Ecommerce.Tax.Domain.CategoryAggregate;

public sealed class Category : AuditableEntity<long>, IAggregateRoot, ISoftDelete
{
    private Category() { }

    public Category(string? name)
        : this()
    {
        Name = Guard.Against.NullOrEmpty(name);
    }

    public string? Name { get; private set; }
    public bool IsDeleted { get; set; }

    public void Delete()
    {
        IsDeleted = true;
    }

    public void UpdateName(string? name)
    {
        Name = Guard.Against.NullOrEmpty(name);
    }
}
