namespace Ecommerce.Location.Features.Districts.ListPagination;

internal sealed class ListDistrictsPaginationValidator
    : AbstractValidator<ListDistrictsPaginationQuery>
{
    public ListDistrictsPaginationValidator()
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
