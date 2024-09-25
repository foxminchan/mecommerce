using Ecommerce.Constant;

namespace Ecommerce.SharedKernel.Model;

public record PaginationRequest(
    int PageIndex = Pagination.DefaultPageIndex,
    int PageSize = Pagination.DefaultPageSize
);

public sealed record PaginationWithSearchRequest(string? Search = null) : PaginationRequest;
