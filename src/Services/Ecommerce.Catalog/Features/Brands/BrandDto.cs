namespace Ecommerce.Catalog.Features.Brands;

public sealed record BrandDto(
    long Id,
    string? Name,
    string? Description,
    string? Slug,
    string? MetaTitle,
    string? MetaDescription,
    string? MetaKeywords,
    int DisplayOrder,
    Guid? ThumbnailId
);
