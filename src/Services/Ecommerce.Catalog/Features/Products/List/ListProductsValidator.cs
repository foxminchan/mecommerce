namespace Ecommerce.Catalog.Features.Products.List;

internal sealed class ListProductsValidator : AbstractValidator<ListProductsQuery>
{
    public ListProductsValidator()
    {
        RuleFor(x => x.Filter)
            .NotNull()
            .ChildRules(x =>
            {
                x.RuleFor(y => y.PageIndex).GreaterThan(0);

                x.RuleFor(y => y.PageSize).GreaterThan(0);

                x.RuleFor(y => y.StartPrice).GreaterThanOrEqualTo(0);

                x.RuleFor(y => y.EndPrice).GreaterThanOrEqualTo(y => y.StartPrice);
            });
    }
}
