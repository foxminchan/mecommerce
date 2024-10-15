namespace Ecommerce.Location.Domain.WardOrCommuneAggregate.Specifications;

public sealed record ListWardOrCommunesRequest(
    long? DistrictId,
    string? Search,
    int PageIndex = Pagination.DefaultPageIndex,
    int PageSize = Pagination.DefaultPageSize
);
