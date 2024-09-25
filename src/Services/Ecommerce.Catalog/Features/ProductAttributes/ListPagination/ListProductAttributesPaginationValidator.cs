namespace Ecommerce.Catalog.Features.ProductAttributes.ListPagination;

internal sealed class ListProductAttributesPaginationValidator
    : AbstractValidator<ListProductAttributesPaginationQuery>
{
    public ListProductAttributesPaginationValidator()
    {
        RuleFor(x => x.Filter)
            .ChildRules(x =>
            {
                x.RuleFor(y => y.PageIndex).GreaterThan(0);

                x.RuleFor(y => y.PageSize).GreaterThan(0);
            });
    }
}
