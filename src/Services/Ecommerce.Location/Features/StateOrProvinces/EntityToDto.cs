using Ecommerce.Location.Domain.StateOrProvinceAggregate;

namespace Ecommerce.Location.Features.StateOrProvinces;

public static class EntityToDto
{
    public static StateOrProvinceDto ToStateOrProvinceDto(this StateOrProvince stateOrProvince)
    {
        return new(
            stateOrProvince.Id,
            stateOrProvince.Name,
            stateOrProvince.Code,
            stateOrProvince.Type,
            stateOrProvince.CountryId
        );
    }

    public static IEnumerable<StateOrProvinceDto> ToStateOrProvinceDtos(
        this IEnumerable<StateOrProvince> stateOrProvinces
    )
    {
        return stateOrProvinces.Select(ToStateOrProvinceDto);
    }
}
