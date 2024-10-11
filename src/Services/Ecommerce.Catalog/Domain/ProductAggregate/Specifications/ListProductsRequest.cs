namespace Ecommerce.Catalog.Domain.ProductAggregate.Specifications;

public sealed record ListProductsRequest(
    decimal StartPrice = 0,
    decimal EndPrice = decimal.MaxValue,
    string? Category = null,
    string? Brand = null
) : PaginationWithFilterRequest;
