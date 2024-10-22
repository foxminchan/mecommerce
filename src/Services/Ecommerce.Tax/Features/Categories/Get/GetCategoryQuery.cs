using Ecommerce.Tax.Domain.CategoryAggregate;
using Ecommerce.Tax.Domain.CategoryAggregate.Specifications;

namespace Ecommerce.Tax.Features.Categories.Get;

internal sealed record GetCategoryQuery(long Id) : IQuery<Result<CategoryDto>>;

internal sealed class GetCategoryHandler(IReadRepository<Category> repository)
    : IQueryHandler<GetCategoryQuery, Result<CategoryDto>>
{
    public async Task<Result<CategoryDto>> Handle(
        GetCategoryQuery request,
        CancellationToken cancellationToken
    )
    {
        var category = await repository.FirstOrDefaultAsync(
            new CategoryFilterSpec(request.Id),
            cancellationToken
        );

        if (category is null)
        {
            return Result.NotFound();
        }

        return category.ToCategoryDto();
    }
}
