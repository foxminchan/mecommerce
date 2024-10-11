namespace Ecommerce.Catalog.Features.Products.ListRelated;

internal sealed class ListProductsRelatedValidator : AbstractValidator<ListProductsRelatedQuery>
{
    public ListProductsRelatedValidator()
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
