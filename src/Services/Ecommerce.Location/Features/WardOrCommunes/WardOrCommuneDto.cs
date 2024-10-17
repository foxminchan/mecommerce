using Type = Ecommerce.Location.Domain.WardOrCommuneAggregate.Type;

namespace Ecommerce.Location.Features.WardOrCommunes;

public sealed record WardOrCommuneDto(long Id, string? Name, Type Type, long DistrictId);
