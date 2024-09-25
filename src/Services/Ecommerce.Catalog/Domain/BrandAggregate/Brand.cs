using Ecommerce.Catalog.Domain.ProductAggregate;

namespace Ecommerce.Catalog.Domain.BrandAggregate;

public sealed class Brand : AuditableEntity<long>, IAggregateRoot, ISoftDelete
{
    private readonly List<Product> _products;

    private Brand()
    {
        _products = [];
    }

    public Brand(
        string? name,
        string? description,
        string? slug,
        string? metaTitle,
        string? metaDescription,
        string? metaKeywords,
        int displayOrder,
        Guid? thumbnailId
    )
        : this()
    {
        Name = Guard.Against.NullOrEmpty(name);
        Description = description;
        Slug = Guard.Against.NullOrEmpty(slug);
        MetaTitle = metaTitle;
        MetaDescription = metaDescription;
        MetaKeywords = metaKeywords;
        DisplayOrder = Guard.Against.NegativeOrZero(displayOrder);
        ThumbnailId = thumbnailId;
    }

    public string? Name { get; private set; }
    public string? Description { get; private set; }
    public string? Slug { get; private set; }
    public string? MetaTitle { get; private set; }
    public string? MetaDescription { get; private set; }
    public string? MetaKeywords { get; private set; }
    public int DisplayOrder { get; private set; }
    public Guid? ThumbnailId { get; private set; }

    public IReadOnlyCollection<Product> Products => _products.AsReadOnly();
    public bool IsDeleted { get; set; }

    public void Delete()
    {
        IsDeleted = true;
    }

    public void UpdateInformation(
        string? name,
        string? description,
        string? slug,
        string? metaTitle,
        string? metaDescription,
        string? metaKeywords,
        int displayOrder,
        Guid? thumbnailId
    )
    {
        Name = Guard.Against.NullOrEmpty(name);
        Description = description;
        Slug = Guard.Against.NullOrEmpty(slug);
        MetaTitle = metaTitle;
        MetaDescription = metaDescription;
        MetaKeywords = metaKeywords;
        DisplayOrder = Guard.Against.NegativeOrZero(displayOrder);
        ThumbnailId = thumbnailId;
    }
}
