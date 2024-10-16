namespace Ecommerce.Location.Domain.DistrictAggregate.Specifications;

public sealed class DistrictFilterSpec : Specification<District>
{
    public DistrictFilterSpec(long id)
    {
        Query.Where(x => x.Id == id && x.WardOrCommunes.Count != 0);
    }
}
