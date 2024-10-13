namespace Ecommerce.Location.Features.Countries.UpdateStatus;

internal sealed class UpdateCountryStatusValidator : AbstractValidator<UpdateCountryStatusCommand>
{
    public UpdateCountryStatusValidator()
    {
        RuleFor(x => x.Id).NotNull();

        RuleFor(x => x.IsActive).NotNull();

        RuleFor(x => x.IsShippingAvailable).NotNull();

        RuleFor(x => x.IsBillingAvailable).NotNull();
    }
}
