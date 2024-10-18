using Ecommerce.Catalog.Domain.ProductAggregate;
using Ecommerce.Catalog.Domain.ProductAggregate.Specifications;
using Ecommerce.Catalog.Domain.ProductAttributeAggregate;
using Ecommerce.Catalog.Domain.VariantAggregate;

namespace Ecommerce.Catalog.Features.Products.Update;

internal sealed record UpdateProductCommand(
    Guid Id,
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
) : ICommand;

[TxScope]
internal sealed class UpdateProductHandler(IRepository<Product> repository)
    : ICommandHandler<UpdateProductCommand>
{
    public async Task<Result> Handle(
        UpdateProductCommand request,
        CancellationToken cancellationToken
    )
    {
        var product = await repository.FirstOrDefaultAsync(
            new ProductFilterSpec(request.Id),
            cancellationToken
        );

        Guard.Against.NotFound(request.Id, product);

        product.Update(
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

        await repository.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }
}
