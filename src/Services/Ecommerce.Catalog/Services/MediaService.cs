using GrpcImageResponse = Ecommerce.Media.Grpc.ImageResponse;
using GrpcMediaClient = Ecommerce.Media.Grpc.Media.MediaClient;

namespace Ecommerce.Catalog.Services;

public sealed class MediaService(GrpcMediaClient mediaClient, ILogger<MediaService> logger)
    : IMediaService
{
    public async Task<ProductImageDto?> GetImageAsync(
        Guid? imageId,
        CancellationToken cancellationToken = default
    )
    {
        if (imageId is null)
        {
            return null;
        }

        if (logger.IsEnabled(LogLevel.Debug))
        {
            logger.LogDebug(
                "[{Service}] - Begin grpc call {Method} with {ImageId}",
                nameof(MediaService),
                nameof(GetImageAsync),
                imageId
            );
        }

        var response = await mediaClient.GetImageAsync(
            new() { Id = imageId.ToString() },
            cancellationToken: cancellationToken
        );

        return response is null ? null : MapToProductImageDto(response);
    }

    private static ProductImageDto MapToProductImageDto(GrpcImageResponse image)
    {
        return new(image.Url, image.Caption);
    }
}
