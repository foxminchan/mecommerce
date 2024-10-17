using Ecommerce.Location.Domain.AddressAggregate;

namespace Ecommerce.Location.Features.Addresses;

public static class EntityToDto
{
    public static AddressDto ToAddressDto(this Address address)
    {
        return new(
            address.Id,
            address.Street,
            address.ZipCode,
            address.WardOrCommune.Name,
            address.WardOrCommune.District.Name,
            address.WardOrCommune.District.StateOrProvince.Name,
            address.WardOrCommune.District.StateOrProvince.Country.Name,
            address.WardOrCommune.District.StateOrProvince.Country.Continent.ToString()
        );
    }

    public static IEnumerable<AddressDto> ToAddressDtos(this IEnumerable<Address> addresses)
    {
        return addresses.Select(ToAddressDto);
    }
}
