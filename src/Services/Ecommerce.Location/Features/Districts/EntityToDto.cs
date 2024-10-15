using Ecommerce.Location.Domain.DistrictAggregate;

namespace Ecommerce.Location.Features.Districts;

public static class EntityToDto
{
    public static DistrictDto ToDistrictDto(this District district)
    {
        return new(district.Id, district.Name, district.StateOrProvinceId);
    }

    public static IEnumerable<DistrictDto> ToDistrictDtos(this IEnumerable<District> districts)
    {
        return districts.Select(ToDistrictDto);
    }
}
