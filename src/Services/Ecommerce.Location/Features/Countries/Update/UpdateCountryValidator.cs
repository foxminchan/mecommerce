namespace Ecommerce.Location.Features.Countries.Update;

internal sealed class UpdateCountryValidator : AbstractValidator<UpdateCountryCommand>
{
    public UpdateCountryValidator()
    {
        RuleFor(x => x.Id).NotNull();

        RuleFor(x => x.FirstCode).NotEmpty().MaximumLength(DataSchemaLength.Micro);

        RuleFor(x => x.SecondCode).MaximumLength(DataSchemaLength.Micro);

        RuleFor(x => x.ThirdCode).MaximumLength(DataSchemaLength.Micro);

        RuleFor(x => x.Continent).IsInEnum();
    }
}
