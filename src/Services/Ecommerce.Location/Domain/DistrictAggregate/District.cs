using Ecommerce.Location.Domain.StateOrProvinceAggregate;
using Ecommerce.Location.Domain.WardOrCommuneAggregate;

namespace Ecommerce.Location.Domain.DistrictAggregate;

public sealed class District : AuditableEntity<long>, IAggregateRoot
{
    private readonly List<WardOrCommune> _wardOrCommunes;

    private District()
    {
        _wardOrCommunes = [];
    }

    public District(string? name, long stateOrProvinceId)
        : this()
    {
        Name = Guard.Against.NullOrEmpty(name);
        StateOrProvinceId = Guard.Against.Null(stateOrProvinceId);
    }

    public string? Name { get; private set; }
    public long StateOrProvinceId { get; private set; }
    public StateOrProvince StateOrProvince { get; private set; } = default!;

    public IReadOnlyCollection<WardOrCommune> WardOrCommunes => _wardOrCommunes.AsReadOnly();

    public void UpdateInformation(string name, long stateOrProvinceId)
    {
        Name = Guard.Against.NullOrEmpty(name);
        StateOrProvinceId = Guard.Against.Null(stateOrProvinceId);
    }
}
