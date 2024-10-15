namespace Ecommerce.Location.Domain.DistrictAggregate.Specifications;

public sealed class DistrictFilterSpec : Specification<District>
{
    public DistrictFilterSpec(long id)
    {
        Query.Where(x => x.Id == id && x.WardOrCommunes.Count != 0);
    }

    public DistrictFilterSpec(long? stateOrProvinceId, string? name)
    {
        if (stateOrProvinceId.HasValue)
        {
            Query.Where(x => x.StateOrProvinceId == stateOrProvinceId);
        }

        if (!string.IsNullOrEmpty(name))
        {
            Query.Where(x => x.Name!.Contains(name));
        }
    }

    public DistrictFilterSpec(ListDistrictsRequest request)
        : this(request.StateOrProvinceId, request.Search)
    {
        Query.Skip((request.PageIndex - 1) * request.PageSize).Take(request.PageSize);
    }
}
