namespace Ecommerce.Location.Features.Countries.Create;

internal sealed class CreateCountryValidator : AbstractValidator<CreateCountryCommand>
{
    public CreateCountryValidator()
    {
        RuleFor(x => x.Name).NotEmpty().MaximumLength(DataSchemaLength.SuperLarge);

        RuleFor(x => x.FirstCode).NotEmpty().MaximumLength(DataSchemaLength.Micro);

        RuleFor(x => x.SecondCode).MaximumLength(DataSchemaLength.Micro);

        RuleFor(x => x.ThirdCode).MaximumLength(DataSchemaLength.Micro);

        RuleFor(x => x.Continent).IsInEnum();

        RuleFor(x => x.IsActive).NotNull();

        RuleFor(x => x.IsShippingAvailable).NotNull();

        RuleFor(x => x.IsBillingAvailable).NotNull();
    }
}
