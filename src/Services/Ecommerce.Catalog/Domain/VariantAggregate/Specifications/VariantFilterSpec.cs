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

    public VariantFilterSpec(int pageIndex, int pageSize)
    {
        Query.Where(x => !x.IsDeleted).Skip((pageIndex - 1) * pageSize).Take(pageSize);
    }
}
