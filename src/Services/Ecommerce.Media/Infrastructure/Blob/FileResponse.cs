namespace Ecommerce.Media.Infrastructure.Blob;

public sealed record FileResponse(Stream Stream, string ContentType, string FileName);
