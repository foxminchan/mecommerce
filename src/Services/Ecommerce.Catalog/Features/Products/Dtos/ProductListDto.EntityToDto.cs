using Ecommerce.Catalog.Domain.ProductAggregate;

namespace Ecommerce.Catalog.Features.Products.Dtos;

public static partial class EntityToDto
{
    public static ProductListDto ToProductListDto(this Product product, string? thumbnailUrl)
    {
        return new(
            product.Id,
            product.Name,
            product.Slug,
            thumbnailUrl,
            product.IsFeatured,
            product.IsDiscontinued,
            product.IsPublished,
            product.TaxId,
            product.BrandId,
            product.Price!.OriginalPrice,
            product.Price!.DiscountPrice
        );
    }

    public static IEnumerable<ProductListDto> ToProductListDtos(
        this IEnumerable<Product> products,
        Dictionary<Guid, string?> productImages
    )
    {
        return products
            .Select(product =>
            {
                var thumbnailUrl = productImages.TryGetValue(
                    (Guid)product.ThumbnailId!,
                    out var url
                )
                    ? url
                    : null;

                return product.ToProductListDto(thumbnailUrl);
            })
            .ToList();
    }
}
