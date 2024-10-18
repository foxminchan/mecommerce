namespace Ecommerce.Inventory.Features.Suppliers.Create;

internal sealed class CreateSupplierValidator : AbstractValidator<CreateSupplierCommand>
{
    public CreateSupplierValidator()
    {
        RuleFor(x => x.Name).NotEmpty().MaximumLength(DataSchemaLength.ExtraLarge);

        RuleFor(x => x.Email).NotEmpty().EmailAddress().MaximumLength(DataSchemaLength.ExtraLarge);

        RuleFor(x => x.Phone)
            .NotEmpty()
            .Matches(@"^\+?(\d[\d-. ]+)?(\([\d-. ]+\))?[\d-. ]+\d$")
            .WithMessage("Invalid phone number.")
            .MaximumLength(DataSchemaLength.Small);

        RuleFor(x => x.ContactPersons)
            .NotEmpty()
            .ForEach(x =>
            {
                x.ChildRules(y =>
                {
                    y.RuleFor(z => z.Name).NotEmpty().MaximumLength(DataSchemaLength.ExtraLarge);

                    y.RuleFor(z => z.Email)
                        .EmailAddress()
                        .MaximumLength(DataSchemaLength.ExtraLarge);

                    y.RuleFor(z => z.Phone)
                        .NotEmpty()
                        .Matches(@"^\+?(\d[\d-. ]+)?(\([\d-. ]+\))?[\d-. ]+\d$")
                        .WithMessage("Invalid phone number.")
                        .MaximumLength(DataSchemaLength.Small);
                });
            });

        RuleFor(x => x.Street).NotEmpty().MaximumLength(DataSchemaLength.SuperLarge);

        RuleFor(x => x.ZipCode).NotEmpty().MaximumLength(DataSchemaLength.Small);

        RuleFor(x => x.WardOrCommuneId).NotEmpty();
    }
}
