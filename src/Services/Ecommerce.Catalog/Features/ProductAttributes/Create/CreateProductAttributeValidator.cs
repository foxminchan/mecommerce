namespace Ecommerce.Catalog.Features.ProductAttributes.Create;

internal sealed class CreateProductAttributeValidator
    : AbstractValidator<CreateProductAttributeCommand>
{
    public CreateProductAttributeValidator()
    {
        RuleFor(x => x.Name).NotEmpty().MaximumLength(DataSchemaLength.ExtraLarge);

        RuleFor(x => x.AttributeGroupId).NotEmpty();
    }
}
