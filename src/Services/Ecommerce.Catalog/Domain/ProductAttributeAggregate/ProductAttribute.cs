using Ecommerce.Catalog.Domain.ProductAttributeGroupAggregate;

namespace Ecommerce.Catalog.Domain.ProductAttributeAggregate;

public sealed class ProductAttribute : AuditableEntity<long>, IAggregateRoot
{
    private ProductAttribute() { }

    public ProductAttribute(string? name, long? attributeGroupId)
        : this()
    {
        Name = Guard.Against.NullOrEmpty(name);
        AttributeGroupId = Guard.Against.Null(attributeGroupId);
    }

    public string? Name { get; private set; }
    public long? AttributeGroupId { get; private set; }
    public ProductAttributeGroup? AttributeGroup { get; private set; } = default!;

    public void UpdateInformation(string? name, long? attributeGroupId)
    {
        Name = Guard.Against.NullOrEmpty(name);
        AttributeGroupId = Guard.Against.Null(attributeGroupId);
    }
}
