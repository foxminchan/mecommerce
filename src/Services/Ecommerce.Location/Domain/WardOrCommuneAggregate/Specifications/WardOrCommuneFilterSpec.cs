namespace Ecommerce.Location.Domain.WardOrCommuneAggregate.Specifications;

public sealed class WardOrCommuneFilterSpec : Specification<WardOrCommune>
{
    public WardOrCommuneFilterSpec(long id)
    {
        Query.Where(x => x.Id == id && x.Addresses.Count != 0);
    }

    public WardOrCommuneFilterSpec(long? districtId, string? name)
    {
        if (districtId is not null)
        {
            Query.Where(x => x.DistrictId == districtId);
        }

        if (!string.IsNullOrEmpty(name))
        {
            Query.Where(x => x.Name!.Contains(name));
        }
    }

    public WardOrCommuneFilterSpec(ListWardOrCommunesRequest request)
        : this(request.DistrictId, request.Search)
    {
        Query.Skip((request.PageIndex - 1) * request.PageSize).Take(request.PageSize);
    }
}
