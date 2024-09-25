namespace Ecommerce.Catalog.Domain.ProductAggregate;

public sealed class Price : ValueObject
{
    public Price() { }

    public Price(decimal originalPrice, decimal? discountPrice = null)
        : this()
    {
        OriginalPrice = Guard.Against.OutOfRange(
            originalPrice,
            nameof(originalPrice),
            0,
            decimal.MaxValue
        );
        DiscountPrice = Guard.Against.OutOfRange(
            discountPrice ?? 0,
            nameof(discountPrice),
            0,
            decimal.MaxValue
        );
    }

    public decimal OriginalPrice { get; }
    public decimal? DiscountPrice { get; }

    protected override IEnumerable<object?> GetEqualityComponents()
    {
        yield return OriginalPrice;
        yield return DiscountPrice;
    }
}
