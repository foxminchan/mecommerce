using Ecommerce.Catalog.Domain.CategoryAggregate;
using Ecommerce.Catalog.Domain.CategoryAggregate.Specifications;

namespace Ecommerce.Catalog.Features.Categories.Update;

internal sealed record UpdateCategoryCommand(
    long Id,
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
) : ICommand;

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

        category.UpdateInformation(
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

        await repository.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }
}
