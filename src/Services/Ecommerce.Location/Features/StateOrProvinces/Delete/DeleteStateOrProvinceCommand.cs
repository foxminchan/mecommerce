using Ecommerce.Location.Domain.StateOrProvinceAggregate;

namespace Ecommerce.Location.Features.StateOrProvinces.Delete;

internal sealed record DeleteStateOrProvinceCommand(long Id) : ICommand;

internal sealed class DeleteStateOrProvinceHandler(IRepository<StateOrProvince> repository)
    : ICommandHandler<DeleteStateOrProvinceCommand>
{
    public async Task<Result> Handle(
        DeleteStateOrProvinceCommand request,
        CancellationToken cancellationToken
    )
    {
        var stateOrProvince = await repository.GetByIdAsync(request.Id, cancellationToken);

        if (stateOrProvince is null)
        {
            return Result.NotFound();
        }

        await repository.DeleteAsync(stateOrProvince, cancellationToken);

        return Result.NoContent();
    }
}
