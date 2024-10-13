namespace Ecommerce.Location.Features.Countries.ListPagination;

internal sealed class ListCountriesPaginationValidator
    : AbstractValidator<ListCountriesPaginationQuery>
{
    public ListCountriesPaginationValidator()
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
