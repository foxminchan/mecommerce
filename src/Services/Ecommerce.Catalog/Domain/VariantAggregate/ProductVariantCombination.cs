namespace Ecommerce.Catalog.Domain.VariantAggregate;

public sealed class ProductVariantCombination : Entity<long>
{
    private ProductVariantCombination() { }

    public ProductVariantCombination(long variantId)
        : this()
    {
        VariantId = Guard.Against.Null(variantId);
    }

    public long VariantId { get; private set; }
    public Variant Variant { get; private set; } = default!;
    public long ProductVariantId { get; set; }
    public ProductVariant ProductVariant { get; private set; } = default!;
}
