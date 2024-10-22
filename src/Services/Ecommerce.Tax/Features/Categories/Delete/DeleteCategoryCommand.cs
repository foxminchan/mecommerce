using Ecommerce.Tax.Domain.CategoryAggregate;
using Ecommerce.Tax.Domain.CategoryAggregate.Specifications;

namespace Ecommerce.Tax.Features.Categories.Delete;

internal sealed record DeleteCategoryCommand(long Id) : ICommand;

internal sealed class DeleteCategoryHandler(IRepository<Category> repository)
    : ICommandHandler<DeleteCategoryCommand>
{
    public async Task<Result> Handle(
        DeleteCategoryCommand request,
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

        category.Delete();

        await repository.SaveChangesAsync(cancellationToken);

        return Result.NoContent();
    }
}
