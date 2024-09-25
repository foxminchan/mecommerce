namespace Ecommerce.Catalog.Features.Products.Update;

internal sealed class UpdateProductValidator : AbstractValidator<UpdateProductCommand>
{
    public UpdateProductValidator(
        ProductVariantDtoValidator productVariantDtoValidator,
        ProductAttributeCombinationDtoValidator attributeCombinationDtoValidator
    )
    {
        RuleFor(x => x.Id).NotEmpty();

        RuleFor(x => x.Name).NotEmpty().MaximumLength(DataSchemaLength.ExtraLarge);

        RuleFor(x => x.ShortDescription).MaximumLength(DataSchemaLength.SuperLarge);

        RuleFor(x => x.Description).MaximumLength(DataSchemaLength.Max);

        RuleFor(x => x.Specification).MaximumLength(DataSchemaLength.UltraMax);

        RuleFor(x => x.Slug).NotEmpty().MaximumLength(DataSchemaLength.ExtraLarge);

        RuleFor(x => x.MetaTitle).MaximumLength(DataSchemaLength.ExtraLarge);

        RuleFor(x => x.MetaDescription).MaximumLength(DataSchemaLength.ExtraLarge);

        RuleFor(x => x.MetaKeywords).MaximumLength(DataSchemaLength.ExtraLarge);

        RuleFor(x => x.Gtin).MaximumLength(DataSchemaLength.Medium);

        RuleFor(x => x.CategoryIds).NotEmpty();

        RuleFor(x => x.ProductVariant)
            .NotEmpty()
            .ForEach(x => x.SetValidator(productVariantDtoValidator));

        RuleFor(x => x.ProductAttributeCombination)
            .NotEmpty()
            .ForEach(x => x.SetValidator(attributeCombinationDtoValidator));

        RuleFor(x => x.TaxId).NotEmpty();
    }
}
