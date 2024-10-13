using Ecommerce.Location.Domain.CountryAggregate;

namespace Ecommerce.Location.Features.Countries;

public static class EntityToDto
{
    public static CountryDto ToCountryDto(this Country country)
    {
        return new(
            country.Id,
            country.Name,
            country.FirstCode,
            country.SecondCode,
            country.ThirdCode,
            country.Continent,
            country.IsActive,
            country.IsShippingAvailable,
            country.IsBillingAvailable
        );
    }

    public static IEnumerable<CountryDto> ToCountryDtos(this IEnumerable<Country> countries)
    {
        return countries.Select(ToCountryDto);
    }
}
