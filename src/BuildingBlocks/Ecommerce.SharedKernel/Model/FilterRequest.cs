using Ecommerce.Constant;

namespace Ecommerce.SharedKernel.Model;

public record PaginationRequest(
    int PageIndex = Pagination.DefaultPageIndex,
    int PageSize = Pagination.DefaultPageSize
);

public record PaginationWithSearchRequest(string? Search = null) : PaginationRequest;

public record PaginationWithFilterRequest(string? SortBy = null, bool IsDescending = false)
    : PaginationWithSearchRequest;
