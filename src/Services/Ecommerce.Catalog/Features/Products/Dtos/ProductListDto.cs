namespace Ecommerce.Catalog.Features.Products.Dtos;

public sealed record ProductListDto(
    Guid Id,
    string? Name,
    string? Slug,
    string? ThumbnailUrl,
    bool IsFeatured,
    bool IsDiscontinued,
    bool IsPublished,
    Guid? TaxId,
    long? BrandId,
    decimal OriginalPrice,
    decimal? DiscountPrice
);
