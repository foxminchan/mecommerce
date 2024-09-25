namespace Ecommerce.Catalog.Features.Variants.Create;

internal sealed class CreateVariantValidator : AbstractValidator<CreateVariantCommand>
{
    public CreateVariantValidator()
    {
        RuleFor(x => x.Name).NotEmpty().MaximumLength(DataSchemaLength.ExtraLarge);

        RuleFor(x => x.Type).IsInEnum();
    }
}
