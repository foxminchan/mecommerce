using Ecommerce.Media.Domain;

namespace Ecommerce.Media.Features.Delete;

internal sealed record DeleteMediaCommand(Guid Id) : ICommand;

internal sealed class DeleteMediaHandler(IRepository<Image> repository, IBlobService blobService)
    : ICommandHandler<DeleteMediaCommand>
{
    public async Task<Result> Handle(
        DeleteMediaCommand request,
        CancellationToken cancellationToken
    )
    {
        var image = await repository.GetByIdAsync(request.Id, cancellationToken);

        if (image is null)
        {
            return Result.NotFound();
        }

        var tasks = new List<Task>
        {
            blobService.DeleteFileAsync(image.FileName!, image.Type, cancellationToken),
            repository.DeleteAsync(image, cancellationToken),
        };

        await Task.WhenAll(tasks);

        return Result.Success();
    }
}
