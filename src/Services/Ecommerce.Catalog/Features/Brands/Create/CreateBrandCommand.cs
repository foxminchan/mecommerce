using Ecommerce.Catalog.Domain.BrandAggregate;

namespace Ecommerce.Catalog.Features.Brands.Create;

internal sealed record CreateBrandCommand(
    string? Name,
    string? Description,
    string? Slug,
    string? MetaTitle,
    string? MetaDescription,
    string? MetaKeywords,
    int DisplayOrder,
    Guid? ThumbnailId
) : ICommand<Result<long>>;

internal sealed class CreateBrandHandler(IRepository<Brand> repository)
    : ICommandHandler<CreateBrandCommand, Result<long>>
{
    public async Task<Result<long>> Handle(
        CreateBrandCommand request,
        CancellationToken cancellationToken
    )
    {
        var brand = new Brand(
            request.Name,
            request.Description,
            request.Slug,
            request.MetaTitle,
            request.MetaDescription,
            request.MetaKeywords,
            request.DisplayOrder,
            request.ThumbnailId
        );

        var result = await repository.AddAsync(brand, cancellationToken);

        return result.Id;
    }
}
