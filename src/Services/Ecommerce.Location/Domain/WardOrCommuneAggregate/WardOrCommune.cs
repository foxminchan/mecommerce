using Ecommerce.Location.Domain.AddressAggregate;
using Ecommerce.Location.Domain.DistrictAggregate;

namespace Ecommerce.Location.Domain.WardOrCommuneAggregate;

public sealed class WardOrCommune : AuditableEntity<long>, IAggregateRoot
{
    private readonly List<Address> _addresses;

    private WardOrCommune()
    {
        _addresses = [];
    }

    public WardOrCommune(string? name, Type type, long districtId)
        : this()
    {
        Name = Guard.Against.NullOrEmpty(name);
        Type = Guard.Against.EnumOutOfRange(type);
        DistrictId = Guard.Against.Null(districtId);
    }

    public string? Name { get; private set; }
    public long DistrictId { get; private set; }
    public Type Type { get; private set; }
    public District District { get; private set; } = default!;

    public IReadOnlyCollection<Address> Addresses => _addresses.AsReadOnly();

    public void UpdateInformation(string? name, Type type, long districtId)
    {
        Name = Guard.Against.NullOrEmpty(name);
        Type = Guard.Against.EnumOutOfRange(type);
        DistrictId = Guard.Against.Null(districtId);
    }
}
