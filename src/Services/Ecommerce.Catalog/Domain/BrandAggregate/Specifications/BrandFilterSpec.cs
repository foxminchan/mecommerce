namespace Ecommerce.Catalog.Domain.BrandAggregate.Specifications;

public sealed class BrandFilterSpec : Specification<Brand>
{
    public BrandFilterSpec(int pageIndex, int pageSize, string? name)
    {
        Query
            .Where(brand => !brand.IsDeleted)
            .OrderBy(brand => brand.DisplayOrder)
            .Skip((pageIndex - 1) * pageSize)
            .Take(pageSize);

        if (!string.IsNullOrWhiteSpace(name))
        {
            Query.Where(brand => brand.Name!.Contains(name));
        }
    }

    public BrandFilterSpec(long id)
    {
        Query.Where(brand => brand.Id == id && !brand.IsDeleted);
    }

    public BrandFilterSpec(long[] ids)
    {
        Query.Where(brand => ids.Contains(brand.Id) && !brand.IsDeleted);
    }
}
