using Ecommerce.Catalog.Domain.BrandAggregate;
using Ecommerce.Catalog.Domain.BrandAggregate.Specifications;

namespace Ecommerce.Catalog.Features.Brands.Update;

internal sealed record UpdateBrandCommand(
    long Id,
    string? Name,
    string? Description,
    string? Slug,
    string? MetaTitle,
    string? MetaDescription,
    string? MetaKeywords,
    int DisplayOrder,
    Guid? ThumbnailId
) : ICommand;

internal sealed class UpdateBrandHandler(IRepository<Brand> repository)
    : ICommandHandler<UpdateBrandCommand>
{
    public async Task<Result> Handle(
        UpdateBrandCommand request,
        CancellationToken cancellationToken
    )
    {
        var brand = await repository.FirstOrDefaultAsync(
            new BrandFilterSpec(request.Id),
            cancellationToken
        );

        if (brand is null)
        {
            return Result.NotFound();
        }

        brand.UpdateInformation(
            request.Name,
            request.Description,
            request.Slug,
            request.MetaTitle,
            request.MetaDescription,
            request.MetaKeywords,
            request.DisplayOrder,
            request.ThumbnailId
        );

        await repository.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }
}
