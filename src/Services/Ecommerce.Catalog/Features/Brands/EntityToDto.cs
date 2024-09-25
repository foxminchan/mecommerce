using Ecommerce.Catalog.Domain.BrandAggregate;

namespace Ecommerce.Catalog.Features.Brands;

public static class EntityToDto
{
    public static BrandDto ToBrandDto(this Brand brand)
    {
        return new(
            brand.Id,
            brand.Name,
            brand.Description,
            brand.Slug,
            brand.MetaTitle,
            brand.MetaDescription,
            brand.MetaKeywords,
            brand.DisplayOrder,
            brand.ThumbnailId
        );
    }

    public static IEnumerable<BrandDto> ToBrandDtos(this IEnumerable<Brand> brands)
    {
        return brands.Select(ToBrandDto);
    }
}
