using Ecommerce.Catalog.Domain.ProductAttributeGroupAggregate;

namespace Ecommerce.Catalog.Features.ProductAttributeGroups;

public static class EntityToDto
{
    public static ProductAttributeGroupDto ToProductAttributeGroupDto(
        this ProductAttributeGroup entity
    )
    {
        return new(entity.Id, entity.Name);
    }

    public static IEnumerable<ProductAttributeGroupDto> ToProductAttributeGroupDtos(
        this IEnumerable<ProductAttributeGroup> entities
    )
    {
        return entities.Select(ToProductAttributeGroupDto);
    }
}
