using Ecommerce.Catalog.Domain.ProductAggregate;
using Ecommerce.Catalog.Domain.ProductAttributeAggregate;
using Ecommerce.Catalog.Domain.VariantAggregate;

namespace Ecommerce.Catalog.Features.Products.Create;

internal sealed record CreateProductCommand(
    string? Name,
    string? ShortDescription,
    string? Description,
    string? Specification,
    string? Gtin,
    string? Slug,
    string? MetaTitle,
    string? MetaDescription,
    string? MetaKeywords,
    bool IsFeatured,
    bool IsPublished,
    bool IsDiscontinued,
    Guid TaxId,
    Guid? ThumbnailId,
    long? BrandId,
    long[] CategoryIds,
    Guid[]? ImageIds,
    Guid[]? ProductRelateIds,
    ProductVariantDto[] ProductVariant,
    ProductAttributeCombinationDto[] ProductAttributeCombination
) : ICommand<Result<Guid>>;

[TxScope]
internal sealed class CreateProductHandler(IRepository<Product> repository)
    : ICommandHandler<CreateProductCommand, Result<Guid>>
{
    public async Task<Result<Guid>> Handle(
        CreateProductCommand request,
        CancellationToken cancellationToken
    )
    {
        var product = new Product(
            request.Name,
            request.ShortDescription,
            request.Description,
            request.Specification,
            request.Gtin,
            request.Slug,
            request.MetaTitle,
            request.MetaDescription,
            request.MetaKeywords,
            request.IsFeatured,
            request.IsPublished,
            request.IsDiscontinued,
            request.TaxId,
            request.ThumbnailId,
            request.BrandId,
            request.CategoryIds,
            request.ImageIds,
            request.ProductRelateIds,
            request
                .ProductVariant.Select(x => new ProductVariant(
                    x.Sku,
                    x.OriginalPrice,
                    x.DiscountPrice,
                    x.DisplayOrder,
                    x.VariantId
                ))
                .ToArray(),
            request
                .ProductAttributeCombination.Select(x => new ProductAttributeCombination(
                    x.Value,
                    x.AttributeId,
                    x.DisplayOrder
                ))
                .ToArray()
        );

        var result = await repository.AddAsync(product, cancellationToken);

        return result.Id;
    }
}
