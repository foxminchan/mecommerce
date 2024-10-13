using Ecommerce.Media.Domain;

namespace Ecommerce.Media.Features.GetFile;

internal sealed record GetFileQuery(Guid Id) : IQuery<Result<FileResponse>>;

internal sealed class GetFileHandler(IReadRepository<Image> repository, IBlobService blobService)
    : IQueryHandler<GetFileQuery, Result<FileResponse>>
{
    public async Task<Result<FileResponse>> Handle(
        GetFileQuery request,
        CancellationToken cancellationToken
    )
    {
        var image = await repository.GetByIdAsync(request.Id, cancellationToken);

        if (image is null)
        {
            return Result.NotFound();
        }

        var file = await blobService.GetFileAsync(image.FileName!, image.Type, cancellationToken);

        return file;
    }
}
