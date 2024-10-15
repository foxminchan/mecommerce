namespace Ecommerce.Location.Domain.StateOrProvinceAggregate.Specifications;

public sealed record ListStateOrProvinceRequest(long? CountryId) : PaginationWithSearchRequest;
