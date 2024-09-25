using Ecommerce.Catalog.Domain.CategoryAggregate;
using Ecommerce.Catalog.Domain.CategoryAggregate.Specifications;

namespace Ecommerce.Catalog.Features.Categories.Delete;

internal sealed class DeleteCategoryValidator : AbstractValidator<DeleteCategoryCommand>
{
    private readonly IReadRepository<Category> _repository;

    public DeleteCategoryValidator(IReadRepository<Category> repository)
    {
        _repository = repository;

        RuleFor(x => x.Id)
            .MustAsync(DoesNotHaveChildrenCategories)
            .WithMessage("Category has children categories.");
    }

    private async Task<bool> DoesNotHaveChildrenCategories(
        long id,
        CancellationToken cancellationToken
    )
    {
        var category = await _repository.FirstOrDefaultAsync(
            new CategoryFilterSpec(id),
            cancellationToken
        );

        return category is null || !category.Children.Any();
    }
}
