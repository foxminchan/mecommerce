using Ecommerce.Tax.Domain.CategoryAggregate;
using Ecommerce.Tax.Domain.CategoryAggregate.Specifications;

namespace Ecommerce.Tax.Features.Categories.List;

internal sealed record ListCategoriesQuery(string? Name) : IQuery<Result<IEnumerable<CategoryDto>>>;

internal sealed class ListCategoriesHandler(IReadRepository<Category> repository)
    : IQueryHandler<ListCategoriesQuery, Result<IEnumerable<CategoryDto>>>
{
    public async Task<Result<IEnumerable<CategoryDto>>> Handle(
        ListCategoriesQuery request,
        CancellationToken cancellationToken = default
    )
    {
        var categories = await repository.ListAsync(
            new CategoryFilterSpec(request.Name),
            cancellationToken
        );

        return Result.Success(categories.ToCategoryDtos());
    }
}
