using Ecommerce.Catalog.Domain.VariantAggregate;

namespace Ecommerce.Catalog.Features.Variants;

public sealed record VariantDto(long Id, string? Name, VariantType Type);
