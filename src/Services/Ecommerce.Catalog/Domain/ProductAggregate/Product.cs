using System.Text.Json.Serialization;
using Ecommerce.Catalog.Domain.BrandAggregate;
using Ecommerce.Catalog.Domain.CategoryAggregate;
using Ecommerce.Catalog.Domain.ProductAttributeAggregate;
using Ecommerce.Catalog.Domain.VariantAggregate;
using NpgsqlTypes;

namespace Ecommerce.Catalog.Domain.ProductAggregate;

public sealed class Product : AuditableEntity, IAggregateRoot, ISoftDelete
{
    private readonly List<ProductAttributeCombination> _productAttributes;
    private readonly List<ProductCategory> _productCategories;
    private readonly List<ProductImage> _productImages;
    private readonly List<ProductRelated> _productRelateds;
    private readonly List<ProductVariant> _productVariants;

    private Product()
    {
        _productImages = [];
        _productRelateds = [];
        _productVariants = [];
        _productAttributes = [];
        _productCategories = [];
    }

    public Product(
        string? name,
        string? shortDescription,
        string? description,
        string? specification,
        string? gtin,
        string? slug,
        string? metaTitle,
        string? metaDescription,
        string? metaKeywords,
        bool isFeatured,
        bool isPublished,
        bool isDiscontinued,
        Guid taxId,
        Guid? thumbnailId,
        long? brandId,
        long[] categoryIds,
        Guid[]? imageIds,
        Guid[]? productRelateIds,
        ProductVariant[] variants,
        ProductAttributeCombination[] attributes
    )
        : this()
    {
        Name = Guard.Against.NullOrEmpty(name);
        ShortDescription = shortDescription;
        Description = description;
        Specification = specification;
        Gtin = gtin;
        Slug = Guard.Against.NullOrEmpty(slug);
        MetaTitle = metaTitle;
        MetaDescription = metaDescription;
        MetaKeywords = metaKeywords;
        IsFeatured = isFeatured;
        IsPublished = isPublished;
        IsDiscontinued = isDiscontinued;
        ThumbnailId = thumbnailId;
        BrandId = brandId;
        TaxId = Guard.Against.Default(taxId);

        _productCategories.AddRange(
            categoryIds.Select(categoryId => new ProductCategory(categoryId))
        );

        if (imageIds is not null)
        {
            _productImages.AddRange(imageIds.Select(imageId => new ProductImage(imageId)));
        }

        if (productRelateIds is not null)
        {
            _productRelateds.AddRange(
                productRelateIds.Select(relatedProductId => new ProductRelated(relatedProductId))
            );
        }

        _productVariants.AddRange(variants);
        _productAttributes.AddRange(attributes);
    }

    public string? Name { get; private set; }
    public string? ShortDescription { get; private set; }
    public string? Description { get; private set; }
    public string? Specification { get; private set; }
    public string? Gtin { get; private set; }
    public string? Slug { get; private set; }
    public string? MetaTitle { get; private set; }
    public string? MetaDescription { get; private set; }
    public string? MetaKeywords { get; private set; }
    public bool IsFeatured { get; private set; }
    public bool IsPublished { get; private set; }
    public bool IsDiscontinued { get; private set; }
    public double AverageRating { get; private set; }
    public int TotalReviews { get; private set; }
    public Guid? ThumbnailId { get; private set; }
    public Guid TaxId { get; private set; }
    public long? BrandId { get; private set; }
    public Brand Brand { get; private set; } = default!;

    [JsonIgnore]
    public NpgsqlTsVector? SearchVector { get; set; }

    public IReadOnlyCollection<ProductImage> ProductImages => _productImages.AsReadOnly();
    public IReadOnlyCollection<ProductRelated> ProductRelateds => _productRelateds.AsReadOnly();
    public IReadOnlyCollection<ProductVariant> ProductVariants => _productVariants.AsReadOnly();
    public IReadOnlyCollection<ProductAttributeCombination> ProductAttributes =>
        _productAttributes.AsReadOnly();
    public IReadOnlyCollection<ProductCategory> ProductCategories =>
        _productCategories.AsReadOnly();
    public bool IsDeleted { get; set; }

    public void Delete()
    {
        IsDeleted = true;
    }

    public void Update(
        string? name,
        string? shortDescription,
        string? description,
        string? specification,
        string? gtin,
        string? slug,
        string? metaTitle,
        string? metaDescription,
        string? metaKeywords,
        bool isFeatured,
        bool isPublished,
        bool isDiscontinued,
        Guid taxId,
        Guid? thumbnailId,
        long? brandId,
        long[] categoryIds,
        Guid[]? imageIds,
        Guid[]? productRelateIds,
        ProductVariant[] variants,
        ProductAttributeCombination[] attributes
    )
    {
        Name = Guard.Against.NullOrEmpty(name);
        ShortDescription = shortDescription;
        Description = description;
        Specification = specification;
        Gtin = gtin;
        Slug = Guard.Against.NullOrEmpty(slug);
        MetaTitle = metaTitle;
        MetaDescription = metaDescription;
        MetaKeywords = metaKeywords;
        IsFeatured = isFeatured;
        IsPublished = isPublished;
        IsDiscontinued = isDiscontinued;
        ThumbnailId = thumbnailId;
        BrandId = brandId;
        TaxId = Guard.Against.Default(taxId);

        _productCategories.AddRange(
            categoryIds.Select(categoryId => new ProductCategory(categoryId))
        );

        if (imageIds is not null)
        {
            _productImages.AddRange(imageIds.Select(imageId => new ProductImage(imageId)));
        }

        if (productRelateIds is not null)
        {
            _productRelateds.AddRange(
                productRelateIds.Select(relatedProductId => new ProductRelated(relatedProductId))
            );
        }

        _productVariants.AddRange(variants);
        _productAttributes.AddRange(attributes);
    }

    public void AddRating(double rating)
    {
        AverageRating = ((AverageRating * TotalReviews) + rating) / (TotalReviews + 1);
        TotalReviews++;
    }

    public void RemoveRating(double rating)
    {
        if (TotalReviews == 0)
        {
            return;
        }

        AverageRating = ((AverageRating * TotalReviews) - rating) / (TotalReviews - 1);
        TotalReviews--;
    }
}
