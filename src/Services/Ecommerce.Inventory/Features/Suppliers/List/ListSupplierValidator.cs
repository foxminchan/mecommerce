namespace Ecommerce.Inventory.Features.Suppliers.List;

internal sealed class ListSupplierValidator : AbstractValidator<ListSupplierQuery>
{
    public ListSupplierValidator()
    {
        RuleFor(x => x.Filter)
            .NotNull()
            .ChildRules(x =>
            {
                x.RuleFor(y => y.PageIndex).GreaterThan(0);

                x.RuleFor(y => y.PageSize).GreaterThan(0);
            });
    }
}
