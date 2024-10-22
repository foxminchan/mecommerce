using Ecommerce.Tax.Domain.CategoryAggregate;

namespace Ecommerce.Tax.Features.Categories;

public static class EntityToDto
{
    public static CategoryDto ToCategoryDto(this Category category)
    {
        return new(category.Id, category.Name);
    }

    public static IEnumerable<CategoryDto> ToCategoryDtos(this IEnumerable<Category> categories)
    {
        return categories.Select(ToCategoryDto);
    }
}
