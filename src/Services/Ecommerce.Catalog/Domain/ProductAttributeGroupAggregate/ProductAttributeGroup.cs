namespace Ecommerce.Catalog.Domain.ProductAttributeGroupAggregate;

public sealed class ProductAttributeGroup : AuditableEntity<long>, IAggregateRoot
{
    private ProductAttributeGroup() { }

    public ProductAttributeGroup(string? name)
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
