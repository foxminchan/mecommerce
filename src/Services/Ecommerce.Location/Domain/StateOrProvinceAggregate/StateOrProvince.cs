using Ecommerce.Location.Domain.CountryAggregate;
using Ecommerce.Location.Domain.DistrictAggregate;

namespace Ecommerce.Location.Domain.StateOrProvinceAggregate;

public sealed class StateOrProvince : AuditableEntity<long>, IAggregateRoot
{
    private readonly List<District> _districts;

    private StateOrProvince()
    {
        _districts = [];
    }

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

    public IReadOnlyCollection<District> Districts => _districts.AsReadOnly();

    public void UpdateInformation(string? name, string? code, Type type, long countryId)
    {
        Name = Guard.Against.NullOrEmpty(name);
        Code = Guard.Against.NullOrEmpty(code);
        Type = Guard.Against.EnumOutOfRange(type);
        CountryId = Guard.Against.NegativeOrZero(countryId);
    }
}
