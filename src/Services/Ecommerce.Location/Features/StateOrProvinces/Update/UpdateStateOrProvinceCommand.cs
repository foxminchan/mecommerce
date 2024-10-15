using Ecommerce.Location.Domain.StateOrProvinceAggregate;
using Type = Ecommerce.Location.Domain.StateOrProvinceAggregate.Type;

namespace Ecommerce.Location.Features.StateOrProvinces.Update;

internal sealed record UpdateStateOrProvinceCommand(
    long Id,
    string? Name,
    string? Code,
    Type Type,
    long CountryId
) : ICommand;

internal sealed class UpdateStateOrProvinceHandler(IRepository<StateOrProvince> repository)
    : ICommandHandler<UpdateStateOrProvinceCommand>
{
    public async Task<Result> Handle(
        UpdateStateOrProvinceCommand request,
        CancellationToken cancellationToken
    )
    {
        var stateOrProvince = await repository.GetByIdAsync(request.Id, cancellationToken);

        if (stateOrProvince is null)
        {
            return Result.NotFound();
        }

        stateOrProvince.UpdateInformation(
            request.Name,
            request.Code,
            request.Type,
            request.CountryId
        );

        await repository.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }
}
