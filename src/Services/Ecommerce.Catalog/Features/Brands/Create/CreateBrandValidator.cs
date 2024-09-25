namespace Ecommerce.Catalog.Features.Brands.Create;

internal sealed class CreateBrandValidator : AbstractValidator<CreateBrandCommand>
{
    public CreateBrandValidator()
    {
        RuleFor(x => x.Name).NotEmpty().MaximumLength(DataSchemaLength.ExtraLarge);

        RuleFor(x => x.Description).MaximumLength(DataSchemaLength.Max);

        RuleFor(x => x.Slug).NotEmpty().MaximumLength(DataSchemaLength.Medium);

        RuleFor(x => x.MetaTitle).MaximumLength(DataSchemaLength.ExtraLarge);

        RuleFor(x => x.MetaDescription).MaximumLength(DataSchemaLength.ExtraLarge);

        RuleFor(x => x.MetaKeywords).MaximumLength(DataSchemaLength.ExtraLarge);

        RuleFor(x => x.DisplayOrder).NotNull().GreaterThan(0);
    }
}
