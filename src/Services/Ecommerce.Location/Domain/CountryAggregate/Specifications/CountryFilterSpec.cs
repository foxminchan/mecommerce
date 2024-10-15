namespace Ecommerce.Location.Domain.CountryAggregate.Specifications;

public sealed class CountryFilterSpec : Specification<Country>
{
    public CountryFilterSpec(long id)
    {
        Query.Where(x => x.Id == id && x.StateOrProvinces.Count != 0);
    }

    public CountryFilterSpec(PaginationRequest request)
    {
        Query.Skip((request.PageIndex - 1) * request.PageSize).Take(request.PageSize);
    }

    public CountryFilterSpec(string? name)
    {
        if (!string.IsNullOrEmpty(name))
        {
            Query.Where(x => x.Name!.Contains(name));
        }
    }
}
