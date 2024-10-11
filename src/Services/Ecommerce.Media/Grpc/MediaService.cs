using Ecommerce.Media.Features;
using Ecommerce.Media.Features.Get;

namespace Ecommerce.Media.Grpc;

internal sealed class MediaService(ISender sender, ILogger<MediaService> logger) : Media.MediaBase
{
    [AllowAnonymous]
    public override async Task<ImageResponse> GetImage(
        ImageRequest request,
        ServerCallContext context
    )
    {
        if (logger.IsEnabled(LogLevel.Debug))
        {
            logger.LogDebug(
                "[{Service}] - Begin grpc call {Method}",
                nameof(MediaService),
                nameof(GetImage)
            );
        }

        var id = Guid.TryParse(request.Id, out var guid) ? guid : Guid.Empty;

        var image = await sender.Send(new GetMediaQuery(id), context.CancellationToken);

        return image.Status == ResultStatus.NotFound ? new() : MapToImageResponse(image.Value);
    }

    private static ImageResponse MapToImageResponse(ImageDto image)
    {
        return new()
        {
            Id = image.Id.ToString(),
            Url = image.Url,
            Caption = image.Caption,
            MediaType = image.Type.ToString(),
        };
    }
}
