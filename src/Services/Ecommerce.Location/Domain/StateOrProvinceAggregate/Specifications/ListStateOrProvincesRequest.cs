namespace Ecommerce.Location.Domain.StateOrProvinceAggregate.Specifications;

public sealed record ListStateOrProvincesRequest(
    long? CountryId,
    string? Search,
    int PageIndex = Pagination.DefaultPageIndex,
    int PageSize = Pagination.DefaultPageSize
);
