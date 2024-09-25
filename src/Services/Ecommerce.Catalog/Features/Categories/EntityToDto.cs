using Ecommerce.Catalog.Domain.CategoryAggregate;

namespace Ecommerce.Catalog.Features.Categories;

public static class EntityToDto
{
    public static CategoryDto ToCategoryDto(this Category category)
    {
        return new(
            category.Id,
            category.Name,
            category.Description,
            category.Slug,
            category.MetaTitle,
            category.MetaDescription,
            category.MetaKeywords,
            category.IsPublished,
            category.DisplayOrder,
            category.ThumbnailId,
            category.ParentId
        );
    }

    public static IEnumerable<CategoryDto> ToCategoryDtos(this IEnumerable<Category> categories)
    {
        return categories.Select(ToCategoryDto);
    }
}
