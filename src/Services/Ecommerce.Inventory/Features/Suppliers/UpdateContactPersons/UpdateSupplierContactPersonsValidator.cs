namespace Ecommerce.Inventory.Features.Suppliers.UpdateContactPersons;

internal sealed class UpdateSupplierContactPersonsValidator
    : AbstractValidator<UpdateSupplierContactPersonsCommand>
{
    public UpdateSupplierContactPersonsValidator()
    {
        RuleFor(x => x.Id).NotNull();

        RuleFor(x => x.ContactPersons)
            .NotNull()
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
    }
}
