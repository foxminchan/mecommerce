using Ecommerce.Constant;

namespace Ecommerce.SharedKernel.Model;

public record PaginationRequest(
    int PageIndex = Pagination.DefaultPageIndex,
    int PageSize = Pagination.DefaultPageSize
);

public sealed record PaginationWithSearchRequest(
    string? Search,
    int PageIndex = Pagination.DefaultPageIndex,
    int PageSize = Pagination.DefaultPageSize
);

public sealed record PaginationWithSearchAndSortRequest(
    string? Search,
    string? SortBy,
    int PageIndex = Pagination.DefaultPageIndex,
    int PageSize = Pagination.DefaultPageSize,
    bool IsDescending = false
);
