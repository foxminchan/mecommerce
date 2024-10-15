namespace Ecommerce.Catalog.Domain.ProductAggregate.Specifications;

public sealed record ListProductsRequest(
    string? Search,
    string? SortBy,
    decimal StartPrice = 0,
    decimal EndPrice = decimal.MaxValue,
    string? Category = null,
    string? Brand = null,
    bool IsFeatured = false,
    int PageIndex = Pagination.DefaultPageIndex,
    int PageSize = Pagination.DefaultPageSize,
    bool IsDescending = false
);
