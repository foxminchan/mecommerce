using Ecommerce.Location.Domain.StateOrProvinceAggregate;

namespace Ecommerce.Location.Domain.DistrictAggregate;

public sealed class District : AuditableEntity<long>, IAggregateRoot
{
    private District() { }

    public District(string? name, long stateOrProvinceId)
        : this()
    {
        Name = Guard.Against.NullOrEmpty(name);
        StateOrProvinceId = Guard.Against.Null(stateOrProvinceId);
    }

    public string? Name { get; private set; }
    public long StateOrProvinceId { get; private set; }
    public StateOrProvince StateOrProvince { get; private set; } = default!;

    public void UpdateInformation(string name, long stateOrProvinceId)
    {
        Name = Guard.Against.NullOrEmpty(name);
        StateOrProvinceId = Guard.Against.Null(stateOrProvinceId);
    }
}
