using Ecommerce.Catalog.Domain.ProductAggregate;

namespace Ecommerce.Catalog.Domain.VariantAggregate;

public sealed class ProductVariant : Entity<long>
{
    private readonly List<ProductVariantCombination> _combinations;

    private ProductVariant()
    {
        _combinations = [];
    }

    public ProductVariant(
        string? sku,
        decimal originalPrice,
        decimal? discountPrice,
        int displayOrder,
        long[] variantId
    )
        : this()
    {
        Sku = sku;
        Price = new(originalPrice, discountPrice);
        DisplayOrder = Guard.Against.NegativeOrZero(displayOrder);
        _combinations.AddRange(variantId.Select(id => new ProductVariantCombination(id)));
    }

    public string? Sku { get; private set; }
    public Price? Price { get; private set; }
    public int DisplayOrder { get; private set; }
    public Guid ProductId { get; set; }
    public Product Product { get; private set; } = default!;

    public IReadOnlyCollection<ProductVariantCombination> Combinations =>
        _combinations.AsReadOnly();
}
