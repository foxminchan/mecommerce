namespace Ecommerce.Catalog.Features.ProductAttributeGroups.Update;

internal sealed class UpdateProductAttributeGroupValidator
    : AbstractValidator<UpdateProductAttributeGroupCommand>
{
    public UpdateProductAttributeGroupValidator()
    {
        RuleFor(x => x.Id).NotNull();

        RuleFor(x => x.Name).NotEmpty().MaximumLength(DataSchemaLength.ExtraLarge);
    }
}
