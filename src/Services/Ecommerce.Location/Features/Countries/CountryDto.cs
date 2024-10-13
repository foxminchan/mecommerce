using Ecommerce.Location.Domain.CountryAggregate;

namespace Ecommerce.Location.Features.Countries;

public sealed record CountryDto(
    long Id,
    string? Name,
    string? FirstCode,
    string? SecondCode,
    string? ThirdCode,
    Continent Continent,
    bool IsActive,
    bool IsShippingAvailable,
    bool IsBillingAvailable
);
