namespace Ecommerce.Location.Features.Districts.Create;

internal sealed class CreateDistrictValidator : AbstractValidator<CreateDistrictCommand>
{
    public CreateDistrictValidator()
    {
        RuleFor(x => x.Name).NotEmpty().MaximumLength(DataSchemaLength.SuperLarge);

        RuleFor(x => x.StateOrProvinceId).NotNull();
    }
}
