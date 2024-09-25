namespace Ecommerce.Catalog.Domain.ProductAggregate;

public sealed class ProductRelated : Entity<long>
{
    private ProductRelated() { }

    public ProductRelated(Guid relatedProductId)
        : this()
    {
        RelatedProductId = Guard.Against.Default(relatedProductId);
    }

    public Guid ProductId { get; set; }
    public Guid RelatedProductId { get; private set; }
    public Product Product { get; private set; } = default!;
    public Product RelatedProduct { get; private set; } = default!;
}
