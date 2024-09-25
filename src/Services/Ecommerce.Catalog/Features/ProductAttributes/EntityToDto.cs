using Ecommerce.Catalog.Domain.ProductAttributeAggregate;

namespace Ecommerce.Catalog.Features.ProductAttributes;

public static class EntityToDto
{
    public static ProductAttributeDto ToProductAttributeDto(this ProductAttribute entity)
    {
        return new(entity.Id, entity.Name, entity.AttributeGroup?.Name);
    }

    public static IEnumerable<ProductAttributeDto> ToProductAttributeDtos(
        this IEnumerable<ProductAttribute> entities
    )
    {
        return entities.Select(ToProductAttributeDto);
    }
}
