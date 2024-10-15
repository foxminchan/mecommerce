namespace Ecommerce.Location.Features.StateOrProvinces.ListPagination;

internal sealed class ListStateOrProvincesPaginationValidator
    : AbstractValidator<ListStateOrProvincesPaginationQuery>
{
    public ListStateOrProvincesPaginationValidator()
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
