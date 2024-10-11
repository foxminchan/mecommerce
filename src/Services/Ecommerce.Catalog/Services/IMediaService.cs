namespace Ecommerce.Catalog.Services;

public interface IMediaService
{
    Task<ProductImageDto?> GetImageAsync(
        Guid? imageId,
        CancellationToken cancellationToken = default
    );
}
