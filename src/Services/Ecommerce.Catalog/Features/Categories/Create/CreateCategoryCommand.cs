using Ecommerce.Catalog.Domain.CategoryAggregate;

namespace Ecommerce.Catalog.Features.Categories.Create;

internal sealed record CreateCategoryCommand(
    string? Name,
    string? Description,
    string? Slug,
    string? MetaTitle,
    string? MetaDescription,
    string? MetaKeywords,
    bool IsPublished,
    int DisplayOrder,
    Guid? ThumbnailId,
    long? ParentId
) : ICommand<Result<long>>;

internal sealed class CreateCategoryHandler(IRepository<Category> repository)
    : ICommandHandler<CreateCategoryCommand, Result<long>>
{
    public async Task<Result<long>> Handle(
        CreateCategoryCommand request,
        CancellationToken cancellationToken
    )
    {
        var category = new Category(
            request.Name,
            request.Description,
            request.Slug,
            request.MetaTitle,
            request.MetaDescription,
            request.IsPublished,
            request.MetaKeywords,
            request.DisplayOrder,
            request.ThumbnailId,
            request.ParentId
        );

        var result = await repository.AddAsync(category, cancellationToken);

        return result.Id;
    }
}
