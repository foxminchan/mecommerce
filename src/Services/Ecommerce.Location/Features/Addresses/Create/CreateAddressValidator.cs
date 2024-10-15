namespace Ecommerce.Location.Features.Addresses.Create;

internal sealed class CreateAddressValidator : AbstractValidator<CreateAddressCommand>
{
    public CreateAddressValidator()
    {
        RuleFor(x => x.Street).NotEmpty().MaximumLength(DataSchemaLength.SuperLarge);

        RuleFor(x => x.ZipCode).NotEmpty().MaximumLength(DataSchemaLength.Small);

        RuleFor(x => x.WardOrCommuneId).NotNull();
    }
}
