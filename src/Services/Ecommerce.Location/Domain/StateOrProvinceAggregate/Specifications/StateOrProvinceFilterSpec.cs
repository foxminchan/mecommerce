namespace Ecommerce.Location.Domain.StateOrProvinceAggregate.Specifications;

public sealed class StateOrProvinceFilterSpec : Specification<StateOrProvince>
{
    public StateOrProvinceFilterSpec(long id)
    {
        Query.Where(x => x.Id == id && x.Districts.Count != 0);
    }

    public StateOrProvinceFilterSpec(long? countryId, string? name)
    {
        if (countryId is not null)
        {
            Query.Where(x => x.CountryId == countryId);
        }

        if (!string.IsNullOrWhiteSpace(name))
        {
            Query.Where(x => x.Name!.Contains(name));
        }
    }

    public StateOrProvinceFilterSpec(ListStateOrProvincesRequest request)
        : this(request.CountryId, request.Search)
    {
        Query.Skip((request.PageIndex - 1) * request.PageSize).Take(request.PageSize);
    }
}
