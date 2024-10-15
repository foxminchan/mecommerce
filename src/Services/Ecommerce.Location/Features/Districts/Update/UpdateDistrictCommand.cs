using Ecommerce.Location.Domain.DistrictAggregate;

namespace Ecommerce.Location.Features.Districts.Update;

internal sealed record UpdateDistrictCommand(long Id, string? Name, long StateOrProvinceId)
    : ICommand;

internal sealed class UpdateDistrictHandler(IRepository<District> repository)
    : ICommandHandler<UpdateDistrictCommand>
{
    public async Task<Result> Handle(
        UpdateDistrictCommand request,
        CancellationToken cancellationToken
    )
    {
        var district = await repository.GetByIdAsync(request.Id, cancellationToken);

        if (district is null)
        {
            return Result.NotFound();
        }

        district.UpdateInformation(request.Name, request.StateOrProvinceId);

        await repository.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }
}
