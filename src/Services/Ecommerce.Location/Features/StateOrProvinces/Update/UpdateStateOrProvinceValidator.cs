namespace Ecommerce.Location.Features.StateOrProvinces.Update;

internal sealed class UpdateStateOrProvinceValidator
    : AbstractValidator<UpdateStateOrProvinceCommand>
{
    public UpdateStateOrProvinceValidator()
    {
        RuleFor(x => x.Id).NotNull();

        RuleFor(x => x.Name).NotEmpty().MaximumLength(DataSchemaLength.SuperLarge);

        RuleFor(x => x.Code).NotEmpty().MaximumLength(DataSchemaLength.Small);

        RuleFor(x => x.Type).NotNull().IsInEnum();

        RuleFor(x => x.CountryId).NotNull();
    }
}
