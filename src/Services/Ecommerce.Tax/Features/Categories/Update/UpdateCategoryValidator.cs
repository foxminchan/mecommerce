namespace Ecommerce.Tax.Features.Categories.Update;

internal sealed class UpdateCategoryValidator : AbstractValidator<UpdateCategoryCommand>
{
    public UpdateCategoryValidator()
    {
        RuleFor(x => x.Id).NotNull();

        RuleFor(x => x.Name).NotEmpty().MaximumLength(DataSchemaLength.ExtraLarge);
    }
}
