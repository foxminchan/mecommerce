namespace Ecommerce.Catalog.Features.Brands.GetByIds;

internal sealed class GetByIdsValidator : AbstractValidator<GetByIdsQuery>
{
    public GetByIdsValidator()
    {
        RuleFor(x => x.Ids).NotEmpty();
    }
}
