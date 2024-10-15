using Type = Ecommerce.Location.Domain.StateOrProvinceAggregate.Type;

namespace Ecommerce.Location.Features.StateOrProvinces;

public sealed record StateOrProvinceDto(
    long Id,
    string? Name,
    string? Code,
    Type Type,
    long CountryId
);
