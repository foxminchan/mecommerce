using Ecommerce.Media.Domain;

namespace Ecommerce.Media.Features.Get;

internal sealed record GetMediaQuery(Guid Id) : IQuery<Result<ImageDto>>;

internal sealed class GetMediaHandler(IReadRepository<Image> repository, IBlobService blobService)
    : IQueryHandler<GetMediaQuery, Result<ImageDto>>
{
    public async Task<Result<ImageDto>> Handle(
        GetMediaQuery request,
        CancellationToken cancellationToken
    )
    {
        var image = await repository.GetByIdAsync(request.Id, cancellationToken);

        if (image is null)
        {
            return Result.NotFound();
        }

        var url = blobService.GetFileUrl(image.FileName!, image.Type);

        return image.ToImageDto(url);
    }
}
