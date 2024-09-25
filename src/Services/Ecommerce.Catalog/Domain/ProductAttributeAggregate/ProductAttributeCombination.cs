using Ecommerce.Catalog.Domain.ProductAggregate;

namespace Ecommerce.Catalog.Domain.ProductAttributeAggregate;

public sealed class ProductAttributeCombination : Entity<long>
{
    private ProductAttributeCombination() { }

    public ProductAttributeCombination(string? value, long attributeId, int displayOrder)
        : this()
    {
        Value = Guard.Against.NullOrEmpty(value);
        AttributeId = Guard.Against.Null(attributeId);
        DisplayOrder = Guard.Against.NegativeOrZero(displayOrder);
    }

    public int DisplayOrder { get; private set; }
    public string? Value { get; private set; }
    public Guid ProductId { get; set; }
    public Product Product { get; private set; } = default!;
    public long AttributeId { get; private set; }
    public ProductAttribute Attribute { get; private set; } = default!;
}
