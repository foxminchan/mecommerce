namespace Ecommerce.Catalog.Features.Products.Dtos;

public sealed record ProductVariantDto(
    string? Sku,
    decimal OriginalPrice,
    decimal? DiscountPrice,
    int DisplayOrder,
    long[] VariantId
);

internal sealed class ProductVariantDtoValidator : AbstractValidator<ProductVariantDto>
{
    public ProductVariantDtoValidator()
    {
        RuleFor(x => x.Sku).NotEmpty().MaximumLength(DataSchemaLength.Medium);

        RuleFor(x => x.OriginalPrice).NotNull().GreaterThanOrEqualTo(0);

        RuleFor(x => x.DiscountPrice).GreaterThanOrEqualTo(-1);

        RuleFor(x => x.DisplayOrder).GreaterThan(0);

        RuleFor(x => x.VariantId).NotEmpty();
    }
}
