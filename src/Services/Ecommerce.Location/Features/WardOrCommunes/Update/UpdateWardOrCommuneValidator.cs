namespace Ecommerce.Location.Features.WardOrCommunes.Update;

internal sealed class UpdateWardOrCommuneValidator : AbstractValidator<UpdateWardOrCommuneCommand>
{
    public UpdateWardOrCommuneValidator()
    {
        RuleFor(x => x.Id).NotNull();

        RuleFor(x => x.Name).NotEmpty().MaximumLength(DataSchemaLength.SuperLarge);

        RuleFor(x => x.Type).NotNull().IsInEnum();

        RuleFor(x => x.DistrictId).NotNull();
    }
}
