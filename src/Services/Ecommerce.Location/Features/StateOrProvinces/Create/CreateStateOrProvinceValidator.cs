using Ecommerce.Location.Domain.StateOrProvinceAggregate;

namespace Ecommerce.Location.Features.StateOrProvinces.Create;

internal sealed class CreateStateOrProvinceValidator : AbstractValidator<StateOrProvince>
{
    public CreateStateOrProvinceValidator()
    {
        RuleFor(x => x.Name).NotEmpty().MaximumLength(DataSchemaLength.SuperLarge);

        RuleFor(x => x.Code).NotEmpty().MaximumLength(DataSchemaLength.Small);

        RuleFor(x => x.Type).NotNull().IsInEnum();

        RuleFor(x => x.CountryId).NotNull();
    }
}
