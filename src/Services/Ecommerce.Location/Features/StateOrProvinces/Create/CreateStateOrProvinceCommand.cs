using Ecommerce.Location.Domain.StateOrProvinceAggregate;
using Type = Ecommerce.Location.Domain.StateOrProvinceAggregate.Type;

namespace Ecommerce.Location.Features.StateOrProvinces.Create;

internal sealed record CreateStateOrProvinceCommand(
    string? Name,
    string? Code,
    Type Type,
    long CountryId
) : ICommand<Result<long>>;

internal sealed class CreateStateOrProvinceHandler(IRepository<StateOrProvince> repository)
    : ICommandHandler<CreateStateOrProvinceCommand, Result<long>>
{
    public async Task<Result<long>> Handle(
        CreateStateOrProvinceCommand request,
        CancellationToken cancellationToken
    )
    {
        var stateOrProvince = new StateOrProvince(
            request.Name,
            request.Code,
            request.Type,
            request.CountryId
        );

        var result = await repository.AddAsync(stateOrProvince, cancellationToken);

        return result.Id;
    }
}
