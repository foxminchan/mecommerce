using Ecommerce.Catalog.Domain.ProductAggregate;

namespace Ecommerce.Catalog.Features.Products.Dtos;

public static partial class EntityToDto
{
    public static ProductInfoDto ToProductInfoDto(this Product entity)
    {
        var skus = entity.ProductVariants.ToDictionary(
            productVariant => productVariant.Id,
            productVariant => productVariant.Sku
        );

        return new(entity.Id, entity.Name, skus);
    }
}
