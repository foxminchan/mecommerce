using Ecommerce.Catalog.Domain.ProductAttributeAggregate;

namespace Ecommerce.Catalog.Features.Products.Dtos;

public static partial class EntityToDto
{
    public static ProductAttributeCombinationDto ToProductAttributeCombinationDto(
        this ProductAttributeCombination productAttributeCombination
    )
    {
        return new(
            productAttributeCombination.Value,
            productAttributeCombination.AttributeId,
            productAttributeCombination.DisplayOrder
        );
    }

    public static List<ProductAttributeCombinationDto> ToProductAttributeCombinationDtos(
        this IEnumerable<ProductAttributeCombination> productAttributeCombinations
    )
    {
        return productAttributeCombinations.Select(ToProductAttributeCombinationDto).ToList();
    }
}
