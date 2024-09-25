using Ecommerce.Media.Domain;

namespace Ecommerce.Media.Features.Create;

internal sealed record CreateMediaCommand(IFormFile File, string? Caption, MediaType MediaType)
    : ICommand<Result<Guid>>;

internal sealed class CreateMediaHandler(IRepository<Image> repository, IBlobService blobService)
    : ICommandHandler<CreateMediaCommand, Result<Guid>>
{
    public async Task<Result<Guid>> Handle(
        CreateMediaCommand request,
        CancellationToken cancellationToken
    )
    {
        var fileName = await blobService.UploadFileAsync(
            request.File,
            request.MediaType,
            cancellationToken
        );

        var image = new Image(fileName, request.Caption, request.MediaType);

        var result = await repository.AddAsync(image, cancellationToken);

        return result.Id;
    }
}
