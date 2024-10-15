namespace Ecommerce.Location.Features.WardOrCommunes.ListPagination;

internal sealed class ListWardOrCommunesPaginationValidator
    : AbstractValidator<ListWardOrCommunesPaginationQuery>
{
    public ListWardOrCommunesPaginationValidator()
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
