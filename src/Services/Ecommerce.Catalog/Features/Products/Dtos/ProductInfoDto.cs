namespace Ecommerce.Catalog.Features.Products.Dtos;

public sealed record ProductInfoDto(Guid Id, string? Name, Dictionary<long, string?> Skus);
