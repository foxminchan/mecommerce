namespace Ecommerce.Location.Domain.DistrictAggregate.Specifications;

public sealed record ListDistrictsRequest(
    long? StateOrProvinceId,
    string? Search,
    int PageIndex = Pagination.DefaultPageIndex,
    int PageSize = Pagination.DefaultPageSize
);
