namespace Ecommerce.Catalog.Features.ProductAttributeGroups.ListPagination;

internal sealed class ListProductAttributeGroupPaginationValidator
    : AbstractValidator<ListProductAttributeGroupPaginationQuery>
{
    public ListProductAttributeGroupPaginationValidator()
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
