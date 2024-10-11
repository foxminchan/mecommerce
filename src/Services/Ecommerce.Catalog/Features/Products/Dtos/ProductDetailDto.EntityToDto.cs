using Ecommerce.Catalog.Domain.ProductAggregate;

namespace Ecommerce.Catalog.Features.Products.Dtos;

public static partial class EntityToDto
{
    public static ProductDetailDto ToProductDetailDto(
        this Product entity,
        string? thumbnailUrl,
        List<ProductImageDto>? productImageDtos
    )
    {
        var productRelates = entity.ProductRelateds.Select(x => x.ProductId).ToList();
        var productCategories = entity.ProductCategories.Select(x => x.CategoryId).ToList();
        var productVariants = entity.ProductVariants.ToList().ToProductVariantDtos();
        var productAttributeCombinations = entity
            .ProductAttributes.ToList()
            .ToProductAttributeCombinationDtos();

        return new(
            entity.Id,
            entity.Name,
            entity.ShortDescription,
            entity.Description,
            entity.Specification,
            entity.Gtin,
            entity.Slug,
            entity.MetaTitle,
            entity.MetaDescription,
            entity.MetaKeywords,
            entity.IsFeatured,
            entity.IsPublished,
            entity.IsDiscontinued,
            entity.AverageRating,
            entity.TotalReviews,
            thumbnailUrl,
            entity.TaxId,
            entity.BrandId,
            productImageDtos,
            productRelates,
            productVariants,
            productAttributeCombinations,
            productCategories
        );
    }
}
