namespace Ecommerce.Catalog.Domain.CategoryAggregate;

public sealed class Category : AuditableEntity<long>, IAggregateRoot, ISoftDelete
{
    private readonly List<ProductCategory> _productCategories;
    private readonly List<Category> _children;

    private Category()
    {
        _productCategories = [];
        _children = [];
    }

    public Category(
        string? name,
        string? description,
        string? slug,
        string? metaTitle,
        string? metaDescription,
        bool isPublished,
        string? metaKeywords,
        int displayOrder,
        Guid? thumbnailId,
        long? parentId
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
        ParentId = parentId;
        IsPublished = isPublished;
    }

    public string? Name { get; private set; }
    public string? Description { get; private set; }
    public string? Slug { get; private set; }
    public string? MetaTitle { get; private set; }
    public string? MetaDescription { get; private set; }
    public string? MetaKeywords { get; private set; }
    public int DisplayOrder { get; private set; }
    public bool IsPublished { get; private set; }
    public long? ParentId { get; private set; }
    public Category? Parent { get; private set; } = default;
    public Guid? ThumbnailId { get; private set; }

    public IReadOnlyCollection<ProductCategory> ProductCategories => _productCategories;
    public IReadOnlyCollection<Category> Children => _children;
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
        bool isPublished,
        string? metaKeywords,
        int displayOrder,
        Guid? thumbnailId,
        long? parentId
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
        ParentId = parentId;
        IsPublished = isPublished;
    }
}
