namespace Ecommerce.Catalog.Domain.ProductAggregate.Specifications;

public static class ProductSpecExpression
{
    public static ISpecificationBuilder<Product> ApplyOrdering(
        this ISpecificationBuilder<Product> builder,
        string? sortBy,
        bool isDescending
    )
    {
        return sortBy switch
        {
            nameof(Product.Name) => isDescending
                ? builder.OrderByDescending(x => x.Name)
                : builder.OrderBy(x => x.Name),
            nameof(Product.CreatedAt) => isDescending
                ? builder.OrderByDescending(x => x.CreatedAt)
                : builder.OrderBy(x => x.CreatedAt),
            nameof(Product.Price.OriginalPrice) => isDescending
                ? builder.OrderByDescending(x => x.Price!.DiscountPrice)
                : builder.OrderBy(x => x.Price!.DiscountPrice),
            nameof(Product.Price.DiscountPrice) => isDescending
                ? builder.OrderByDescending(x => x.Price!.DiscountPrice)
                : builder.OrderBy(x => x.Price!.DiscountPrice),
            _ => isDescending
                ? builder.OrderByDescending(x => x.Name)
                : builder.OrderBy(x => x.Name),
        };
    }

    public static ISpecificationBuilder<Product> ApplyPaging(
        this ISpecificationBuilder<Product> builder,
        int pageIndex,
        int pageSize
    )
    {
        return builder.Skip((pageIndex - 1) * pageSize).Take(pageSize);
    }

    public static ISpecificationBuilder<Product> ApplyPriceRange(
        this ISpecificationBuilder<Product> builder,
        decimal minPrice,
        decimal maxPrice
    )
    {
        return builder.Where(x =>
            x.Price!.OriginalPrice >= minPrice && x.Price!.OriginalPrice <= maxPrice
        );
    }
}
