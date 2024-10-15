namespace Ecommerce.Location.Features.Addresses.Update;

internal sealed class UpdateAddressValidator : AbstractValidator<UpdateAddressCommand>
{
    public UpdateAddressValidator()
    {
        RuleFor(x => x.Id).NotEmpty();

        RuleFor(x => x.Street).NotEmpty().MaximumLength(DataSchemaLength.SuperLarge);

        RuleFor(x => x.ZipCode).NotEmpty().MaximumLength(DataSchemaLength.Small);

        RuleFor(x => x.WardOrCommuneId).NotEmpty();
    }
}
