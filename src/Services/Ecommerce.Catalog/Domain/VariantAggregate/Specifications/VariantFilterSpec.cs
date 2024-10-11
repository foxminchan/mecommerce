namespace Ecommerce.Catalog.Domain.VariantAggregate.Specifications;

public sealed class VariantFilterSpec : Specification<Variant>
{
    public VariantFilterSpec()
    {
        Query.Where(x => !x.IsDeleted);
    }

    public VariantFilterSpec(long id)
    {
        Query.Where(x => x.Id == id && !x.IsDeleted);
    }

    public VariantFilterSpec(PaginationRequest request)
    {
        Query
            .Where(x => !x.IsDeleted)
            .Skip((request.PageIndex - 1) * request.PageSize)
            .Take(request.PageSize);
    }
}
