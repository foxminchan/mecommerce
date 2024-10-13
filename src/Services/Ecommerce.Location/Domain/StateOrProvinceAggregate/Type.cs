using System.Text.Json.Serialization;

namespace Ecommerce.Location.Domain.StateOrProvinceAggregate;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum Type : byte
{
    State = 0,
    City = 1,
    Province = 2,
}
