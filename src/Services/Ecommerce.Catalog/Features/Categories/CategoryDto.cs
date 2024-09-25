namespace Ecommerce.Catalog.Features.Categories;

public sealed record CategoryDto(
    long Id,
    string? Name,
    string? Description,
    string? Slug,
    string? MetaTitle,
    string? MetaDescription,
    string? MetaKeywords,
    bool IsPublished,
    int DisplayOrder,
    Guid? ThumbnailId,
    long? ParentId
);
