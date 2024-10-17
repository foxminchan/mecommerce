using Ecommerce.Location.Domain.WardOrCommuneAggregate;

namespace Ecommerce.Location.Features.WardOrCommunes;

public static class EntityToDto
{
    public static WardOrCommuneDto ToWardOrCommuneDto(this WardOrCommune wardOrCommune)
    {
        return new(
            wardOrCommune.Id,
            wardOrCommune.Name,
            wardOrCommune.Type,
            wardOrCommune.DistrictId
        );
    }

    public static IEnumerable<WardOrCommuneDto> ToWardOrCommuneDtos(
        this IEnumerable<WardOrCommune> wardOrCommunes
    )
    {
        return wardOrCommunes.Select(ToWardOrCommuneDto);
    }
}
