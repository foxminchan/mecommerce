namespace Ecommerce.Location.Features.WardOrCommunes.Create;

internal sealed class CreateWardOrCommuneValidator : AbstractValidator<CreateWardOrCommuneCommand>
{
    public CreateWardOrCommuneValidator()
    {
        RuleFor(x => x.Name).NotEmpty().MaximumLength(DataSchemaLength.SuperLarge);

        RuleFor(x => x.Type).NotNull().IsInEnum();

        RuleFor(x => x.DistrictId).NotNull();
    }
}
