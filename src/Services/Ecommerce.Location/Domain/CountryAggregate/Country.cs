using Ecommerce.Location.Domain.StateOrProvinceAggregate;

namespace Ecommerce.Location.Domain.CountryAggregate;

public sealed class Country : AuditableEntity<long>, IAggregateRoot
{
    private readonly List<StateOrProvince> _stateOrProvinces;

    private Country()
    {
        _stateOrProvinces = [];
    }

    public Country(
        string? name,
        string? firstCode,
        string? secondCode,
        string? thirdCode,
        Continent continent,
        bool isActive,
        bool isShippingAvailable,
        bool isBillingAvailable
    )
        : this()
    {
        Name = Guard.Against.NullOrEmpty(name);
        FirstCode = Guard.Against.NullOrEmpty(firstCode);
        SecondCode = secondCode;
        ThirdCode = thirdCode;
        IsActive = isActive;
        Continent = Guard.Against.EnumOutOfRange(continent);
        IsShippingAvailable = isShippingAvailable;
        IsBillingAvailable = isBillingAvailable;
    }

    public string? Name { get; private set; }
    public string? FirstCode { get; private set; }
    public string? SecondCode { get; private set; }
    public string? ThirdCode { get; private set; }
    public Continent Continent { get; private set; }
    public bool IsActive { get; private set; }
    public bool IsShippingAvailable { get; private set; }
    public bool IsBillingAvailable { get; private set; }

    public IReadOnlyCollection<StateOrProvince> StateOrProvinces => _stateOrProvinces.AsReadOnly();

    public void UpdateStatus(bool isActive, bool isShippingAvailable, bool isBillingAvailable)
    {
        IsActive = isActive;
        IsShippingAvailable = isShippingAvailable;
        IsBillingAvailable = isBillingAvailable;
    }

    public void UpdateInformation(
        string? name,
        string? firstCode,
        string? secondCode,
        string? thirdCode,
        Continent continent
    )
    {
        Name = Guard.Against.NullOrEmpty(name);
        FirstCode = Guard.Against.NullOrEmpty(firstCode);
        SecondCode = secondCode;
        ThirdCode = thirdCode;
        Continent = Guard.Against.EnumOutOfRange(continent);
    }
}
