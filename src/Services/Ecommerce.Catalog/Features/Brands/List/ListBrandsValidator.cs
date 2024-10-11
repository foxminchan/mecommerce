namespace Ecommerce.Catalog.Features.Brands.List;

internal sealed class ListBrandsValidator : AbstractValidator<ListBrandsQuery>
{
    public ListBrandsValidator()
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
