using Ecommerce.Location.Domain.CountryAggregate;

namespace Ecommerce.Location.Domain.StateOrProvinceAggregate;

public sealed class StateOrProvince : AuditableEntity<long>, IAggregateRoot
{
    private StateOrProvince() { }

    public StateOrProvince(string? name, string? code, Type type, long countryId)
        : this()
    {
        Name = Guard.Against.NullOrEmpty(name);
        Code = Guard.Against.NullOrEmpty(code);
        Type = Guard.Against.EnumOutOfRange(type);
        CountryId = Guard.Against.NegativeOrZero(countryId);
    }

    public string? Name { get; private set; }
    public string? Code { get; private set; }
    public Type Type { get; private set; }
    public long CountryId { get; private set; }
    public Country Country { get; private set; } = default!;

    public void UpdateInformation(string name, string code, Type type, long countryId)
    {
        Name = Guard.Against.NullOrEmpty(name);
        Code = Guard.Against.NullOrEmpty(code);
        Type = Guard.Against.EnumOutOfRange(type);
        CountryId = Guard.Against.NegativeOrZero(countryId);
    }
}
