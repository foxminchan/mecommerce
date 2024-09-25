namespace Ecommerce.Catalog.Features.ProductAttributeGroups.Create;

internal sealed class CreateAttributeGroupValidator : AbstractValidator<CreateAttributeGroupCommand>
{
    public CreateAttributeGroupValidator()
    {
        RuleFor(x => x.Name).NotEmpty().MaximumLength(DataSchemaLength.ExtraLarge);
    }
}
