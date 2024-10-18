using Ecommerce.Location.Domain.DistrictAggregate;

namespace Ecommerce.Location.Features.Districts.Delete;

internal sealed record DeleteDistrictCommand(long Id) : ICommand;

internal sealed class DeleteDistrictHandler(IRepository<District> repository)
    : ICommandHandler<DeleteDistrictCommand>
{
    public async Task<Result> Handle(
        DeleteDistrictCommand request,
        CancellationToken cancellationToken
    )
    {
        var district = await repository.GetByIdAsync(request.Id, cancellationToken);

        if (district is null)
        {
            return Result.NotFound();
        }

        await repository.DeleteAsync(district, cancellationToken);

        return Result.NoContent();
    }
}
