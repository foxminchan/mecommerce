using Ecommerce.Catalog.Domain.ProductAggregate;

namespace Ecommerce.Catalog.Domain.CategoryAggregate;

public sealed class ProductCategory : Entity<long>
{
    private ProductCategory() { }

    public ProductCategory(long categoryId)
        : this()
    {
        CategoryId = Guard.Against.Null(categoryId);
    }

    public Guid ProductId { get; set; }
    public long CategoryId { get; private set; }
    public Product Product { get; private set; } = default!;
    public Category Category { get; private set; } = default!;
}
