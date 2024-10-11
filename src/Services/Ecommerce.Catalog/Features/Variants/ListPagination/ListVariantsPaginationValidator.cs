namespace Ecommerce.Catalog.Features.Variants.ListPagination;

internal sealed class ListVariantsPaginationValidator
    : AbstractValidator<ListVariantsPaginationQuery>
{
    public ListVariantsPaginationValidator()
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
