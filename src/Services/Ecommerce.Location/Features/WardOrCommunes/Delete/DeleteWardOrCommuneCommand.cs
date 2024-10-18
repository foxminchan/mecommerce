using Ecommerce.Location.Domain.WardOrCommuneAggregate;

namespace Ecommerce.Location.Features.WardOrCommunes.Delete;

internal sealed record DeleteWardOrCommuneCommand(long Id) : ICommand;

internal sealed class DeleteWardOrCommuneHandler(IRepository<WardOrCommune> repository)
    : ICommandHandler<DeleteWardOrCommuneCommand>
{
    public async Task<Result> Handle(
        DeleteWardOrCommuneCommand request,
        CancellationToken cancellationToken
    )
    {
        var wardOrCommune = await repository.GetByIdAsync(request.Id, cancellationToken);

        if (wardOrCommune is null)
        {
            return Result.NotFound();
        }

        await repository.DeleteAsync(wardOrCommune, cancellationToken);

        return Result.NoContent();
    }
}
