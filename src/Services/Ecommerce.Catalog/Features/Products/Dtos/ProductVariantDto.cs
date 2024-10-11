namespace Ecommerce.Catalog.Features.Products.Dtos;

public sealed record ProductVariantDto(
    string? Sku,
    decimal OriginalPrice,
    decimal? DiscountPrice,
    int DisplayOrder,
    long[] VariantId
);
