using Ecommerce.Location.Domain.WardOrCommuneAggregate;
using Type = Ecommerce.Location.Domain.WardOrCommuneAggregate.Type;

namespace Ecommerce.Location.Features.WardOrCommunes.Create;

internal sealed record CreateWardOrCommuneCommand(string? Name, Type Type, long DistrictId)
    : ICommand<Result<long>>;

internal sealed class CreateWardOrCommuneHandler(IRepository<WardOrCommune> repository)
    : ICommandHandler<CreateWardOrCommuneCommand, Result<long>>
{
    public async Task<Result<long>> Handle(
        CreateWardOrCommuneCommand request,
        CancellationToken cancellationToken
    )
    {
        var wardOrCommune = new WardOrCommune(request.Name, request.Type, request.DistrictId);

        var result = await repository.AddAsync(wardOrCommune, cancellationToken);

        return result.Id;
    }
}
