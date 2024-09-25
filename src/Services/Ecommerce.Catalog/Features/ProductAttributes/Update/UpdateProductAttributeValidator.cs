namespace Ecommerce.Catalog.Features.ProductAttributes.Update;

internal sealed class UpdateProductAttributeValidator
    : AbstractValidator<UpdateProductAttributeCommand>
{
    public UpdateProductAttributeValidator()
    {
        RuleFor(x => x.Id).NotEmpty();

        RuleFor(x => x.Name).NotEmpty().MaximumLength(DataSchemaLength.ExtraLarge);

        RuleFor(x => x.AttributeGroupId).NotEmpty();
    }
}
