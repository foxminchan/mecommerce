namespace Ecommerce.Location.Features.Districts.Update;

internal sealed class UpdateDistrictValidator : AbstractValidator<UpdateDistrictCommand>
{
    public UpdateDistrictValidator()
    {
        RuleFor(x => x.Id).NotNull();

        RuleFor(x => x.Name).NotEmpty().MaximumLength(DataSchemaLength.SuperLarge);

        RuleFor(x => x.StateOrProvinceId).NotNull();
    }
}
