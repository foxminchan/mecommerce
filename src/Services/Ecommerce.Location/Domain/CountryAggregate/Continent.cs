using System.Text.Json.Serialization;

namespace Ecommerce.Location.Domain.CountryAggregate;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum Continent : byte
{
    Africa = 0,
    Antarctica = 1,
    Asia = 2,
    Europe = 3,
    America = 4,
    Oceania = 5,
}
