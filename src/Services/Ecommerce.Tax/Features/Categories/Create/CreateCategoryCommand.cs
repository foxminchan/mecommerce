using Ecommerce.Tax.Domain.CategoryAggregate;

namespace Ecommerce.Tax.Features.Categories.Create;

internal sealed record CreateCategoryCommand(string? Name) : ICommand<Result<long>>;

internal sealed class CreateCategoryHandler(IRepository<Category> repository)
    : ICommandHandler<CreateCategoryCommand, Result<long>>
{
    public async Task<Result<long>> Handle(
        CreateCategoryCommand request,
        CancellationToken cancellationToken
    )
    {
        var category = new Category(request.Name);

        var result = await repository.AddAsync(category, cancellationToken);

        return result.Id;
    }
}
