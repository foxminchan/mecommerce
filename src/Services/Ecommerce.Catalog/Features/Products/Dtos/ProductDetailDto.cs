namespace Ecommerce.Catalog.Features.Products.Dtos;

public sealed record ProductDetailDto(
    Guid Id,
    string? Name,
    string? ShortDescription,
    string? Description,
    string? Specification,
    string? Gtin,
    string? Slug,
    string? MetaTitle,
    string? MetaDescription,
    string? MetaKeywords,
    bool IsFeatured,
    bool IsPublished,
    bool IsDiscontinued,
    double AverageRating,
    int TotalReviews,
    string? ThumbnailUrl,
    Guid TaxId,
    long? BrandId,
    List<ProductImageDto>? ProductImages,
    List<Guid>? ProductRelateds,
    List<ProductVariantDto>? ProductVariants,
    List<ProductAttributeCombinationDto>? ProductAttributes,
    List<long>? ProductCategories
);
