namespace Ecommerce.Inventory.Features.Suppliers.Update;

internal sealed class UpdateSupplierValidator : AbstractValidator<UpdateSupplierCommand>
{
    public UpdateSupplierValidator()
    {
        RuleFor(x => x.Id).NotNull();

        RuleFor(x => x.Name).NotEmpty().MaximumLength(DataSchemaLength.ExtraLarge);

        RuleFor(x => x.Email).NotEmpty().EmailAddress().MaximumLength(DataSchemaLength.ExtraLarge);

        RuleFor(x => x.Phone)
            .NotEmpty()
            .Matches(@"^\+?(\d[\d-. ]+)?(\([\d-. ]+\))?[\d-. ]+\d$")
            .WithMessage("Invalid phone number.")
            .MaximumLength(DataSchemaLength.Small);

        RuleFor(x => x.Street).NotEmpty().MaximumLength(DataSchemaLength.SuperLarge);

        RuleFor(x => x.ZipCode).NotEmpty().MaximumLength(DataSchemaLength.Small);

        RuleFor(x => x.WardOrCommuneId).NotEmpty();
    }
}
