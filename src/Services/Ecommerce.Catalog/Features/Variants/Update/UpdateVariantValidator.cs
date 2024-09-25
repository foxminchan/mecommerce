namespace Ecommerce.Catalog.Features.Variants.Update;

internal sealed class UpdateVariantValidator : AbstractValidator<UpdateVariantCommand>
{
    public UpdateVariantValidator()
    {
        RuleFor(x => x.Name).NotEmpty().MaximumLength(DataSchemaLength.ExtraLarge);

        RuleFor(x => x.Name).NotEmpty();

        RuleFor(x => x.Type).IsInEnum();
    }
}
