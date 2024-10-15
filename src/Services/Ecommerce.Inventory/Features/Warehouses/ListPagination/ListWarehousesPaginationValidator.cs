namespace Ecommerce.Inventory.Features.Warehouses.ListPagination;

internal sealed class ListWarehousesPaginationValidator
    : AbstractValidator<ListWarehousesPaginationQuery>
{
    public ListWarehousesPaginationValidator()
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
