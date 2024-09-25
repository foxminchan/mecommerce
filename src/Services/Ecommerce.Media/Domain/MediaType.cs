using System.Text.Json.Serialization;

namespace Ecommerce.Media.Domain;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum MediaType
{
    Product = 0,
    Specification = 1,
    Brand = 2,
    Category = 3,
    User = 4,
    Comment = 5,
}
