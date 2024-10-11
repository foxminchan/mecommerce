namespace Ecommerce.Catalog.Features.Products.Dtos;

public sealed record ProductAttributeCombinationDto(
    string? Value,
    long AttributeId,
    int DisplayOrder
);
