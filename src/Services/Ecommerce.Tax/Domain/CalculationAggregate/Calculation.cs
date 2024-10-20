using Ecommerce.Tax.Domain.CategoryAggregate;

namespace Ecommerce.Tax.Domain.CalculationAggregate;

public sealed class Calculation : AuditableEntity<long>, IAggregateRoot, ISoftDelete
{
    private Calculation() { }

    public Calculation(double rate, long stateOrProvinceId, long categoryId)
        : this()
    {
        StateOrProvinceId = Guard.Against.Null(stateOrProvinceId);
        CategoryId = Guard.Against.Null(categoryId);
        Rate = Guard.Against.NegativeOrZero(rate);
    }

    public double Rate { get; private set; }
    public long StateOrProvinceId { get; private set; }
    public long CategoryId { get; private set; }
    public Category Category { get; private set; } = default!;
    public bool IsDeleted { get; set; }

    public void Delete()
    {
        IsDeleted = true;
    }

    public void UpdateRate(double rate)
    {
        Rate = Guard.Against.NegativeOrZero(rate);
    }

    public void UpdateInformation(long stateOrProvinceId, long categoryId)
    {
        StateOrProvinceId = Guard.Against.Null(stateOrProvinceId);
        CategoryId = Guard.Against.Null(categoryId);
    }
}
