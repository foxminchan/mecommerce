namespace Ecommerce.Location.Features.Addresses;

public sealed record AddressDto(
    Guid Id,
    string? Street,
    string? ZipCode,
    string? WardOrCommune,
    string? District,
    string? StateOrProvince,
    string? Country,
    string? Continent
);
