using Ecommerce.Catalog.Domain.VariantAggregate;

namespace Ecommerce.Catalog.Features.Products.Dtos;

public static partial class EntityToDto
{
    public static ProductVariantDto ToProductVariantDto(this ProductVariant productVariant)
    {
        return new(
            productVariant.Sku,
            productVariant.Price!.OriginalPrice,
            productVariant.Price!.DiscountPrice,
            productVariant.DisplayOrder,
            productVariant.Combinations.Select(x => x.VariantId).ToArray()
        );
    }

    public static List<ProductVariantDto> ToProductVariantDtos(
        this IEnumerable<ProductVariant> productVariants
    )
    {
        return productVariants.Select(ToProductVariantDto).ToList();
    }
}
