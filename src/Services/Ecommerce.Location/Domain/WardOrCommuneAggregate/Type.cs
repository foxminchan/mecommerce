using System.Text.Json.Serialization;

namespace Ecommerce.Location.Domain.WardOrCommuneAggregate;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum Type : byte
{
    Ward = 0,
    Commune = 1,
}
