using Ecommerce.Catalog.Domain.VariantAggregate;

namespace Ecommerce.Catalog.Features.Variants;

public static class EntityToDto
{
    public static VariantDto ToVariantDto(this Variant entity)
    {
        return new(entity.Id, entity.Name, entity.Type);
    }

    public static IEnumerable<VariantDto> ToVariantDtos(this IEnumerable<Variant> entities)
    {
        return entities.Select(ToVariantDto);
    }
}
