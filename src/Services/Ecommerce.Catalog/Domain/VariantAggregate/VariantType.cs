using System.Text.Json.Serialization;

namespace Ecommerce.Catalog.Domain.VariantAggregate;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum VariantType
{
    Color = 0,
    Storage = 1,
    Ram = 2,
}
