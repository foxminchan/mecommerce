using Ecommerce.Catalog.Domain.CategoryAggregate;
using Ecommerce.Catalog.Domain.CategoryAggregate.Specifications;

namespace Ecommerce.Catalog.Features.Categories.List;

internal sealed record ListCategoriesQuery(string? Name) : IQuery<Result<IEnumerable<CategoryDto>>>;

internal sealed class ListCategoriesHandler(IReadRepository<Category> repository)
    : IQueryHandler<ListCategoriesQuery, Result<IEnumerable<CategoryDto>>>
{
    public async Task<Result<IEnumerable<CategoryDto>>> Handle(
        ListCategoriesQuery query,
        CancellationToken cancellationToken
    )
    {
        var categories = await repository.ListAsync(
            new CategoryFilterSpec(query.Name),
            cancellationToken
        );

        return Result.Success(categories.ToCategoryDtos());
    }
}
