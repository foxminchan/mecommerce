namespace Ecommerce.Catalog.Domain.BrandAggregate.Specifications;

public sealed class BrandFilterSpec : Specification<Brand>
{
    public BrandFilterSpec(PaginationWithSearchRequest request)
    {
        if (!string.IsNullOrWhiteSpace(request.Search))
        {
            Query.Where(brand => brand.Name!.Contains(request.Search));
        }

        Query
            .Where(brand => !brand.IsDeleted)
            .OrderBy(brand => brand.DisplayOrder)
            .Skip((request.PageIndex - 1) * request.PageSize)
            .Take(request.PageSize);
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
