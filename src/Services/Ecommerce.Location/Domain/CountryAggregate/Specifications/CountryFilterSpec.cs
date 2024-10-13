namespace Ecommerce.Location.Domain.CountryAggregate.Specifications;

public sealed class CountryFilterSpec : Specification<Country>
{
    public CountryFilterSpec(PaginationRequest request)
    {
        Query.Skip((request.PageIndex - 1) * request.PageSize).Take(request.PageSize);
    }
}
