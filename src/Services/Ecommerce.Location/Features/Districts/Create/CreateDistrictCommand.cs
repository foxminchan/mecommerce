using Ecommerce.Location.Domain.DistrictAggregate;

namespace Ecommerce.Location.Features.Districts.Create;

internal sealed record CreateDistrictCommand(string? Name, long StateOrProvinceId)
    : ICommand<Result<long>>;

internal sealed class CreateDistrictHandler(IRepository<District> repository)
    : IRequestHandler<CreateDistrictCommand, Result<long>>
{
    public async Task<Result<long>> Handle(
        CreateDistrictCommand request,
        CancellationToken cancellationToken
    )
    {
        var district = new District(request.Name, request.StateOrProvinceId);

        var result = await repository.AddAsync(district, cancellationToken);

        return result.Id;
    }
}
