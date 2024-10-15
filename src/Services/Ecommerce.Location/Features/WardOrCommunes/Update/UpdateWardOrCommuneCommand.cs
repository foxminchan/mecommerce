using Ecommerce.Location.Domain.WardOrCommuneAggregate;
using Type = Ecommerce.Location.Domain.WardOrCommuneAggregate.Type;

namespace Ecommerce.Location.Features.WardOrCommunes.Update;

internal sealed record UpdateWardOrCommuneCommand(long Id, string? Name, Type Type, long DistrictId)
    : ICommand;

internal sealed class UpdateWardOrCommuneHandler(IRepository<WardOrCommune> repository)
    : ICommandHandler<UpdateWardOrCommuneCommand>
{
    public async Task<Result> Handle(
        UpdateWardOrCommuneCommand request,
        CancellationToken cancellationToken
    )
    {
        var wardOrCommune = await repository.GetByIdAsync(request.Id, cancellationToken);

        if (wardOrCommune is null)
        {
            return Result.NotFound();
        }

        wardOrCommune.UpdateInformation(request.Name, request.Type, request.DistrictId);

        await repository.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }
}
