using System.Text.Json.Serialization;

namespace Ecommerce.Inventory.Domain.WarehouseAggregate;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum Status : byte
{
    Available = 0,
    AlmostFull = 1,
    Full = 2,
    Inactive = 3,
}
