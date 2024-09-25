using Ecommerce.Media.Domain;

namespace Ecommerce.Media.Features;

public sealed record ImageDto(Guid Id, string? Url, string? Caption, MediaType Type);
