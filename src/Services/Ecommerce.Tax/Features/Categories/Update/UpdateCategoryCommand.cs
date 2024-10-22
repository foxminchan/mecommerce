using Ecommerce.Tax.Domain.CategoryAggregate;
using Ecommerce.Tax.Domain.CategoryAggregate.Specifications;

namespace Ecommerce.Tax.Features.Categories.Update;

internal sealed record UpdateCategoryCommand(long Id, string? Name) : ICommand;

internal sealed class UpdateCategoryHandler(IRepository<Category> repository)
    : ICommandHandler<UpdateCategoryCommand>
{
    public async Task<Result> Handle(
        UpdateCategoryCommand request,
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

        category.UpdateName(request.Name);

        await repository.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }
}
