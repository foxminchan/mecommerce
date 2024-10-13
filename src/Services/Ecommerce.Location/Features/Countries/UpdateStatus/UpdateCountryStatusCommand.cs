using Ecommerce.Location.Domain.CountryAggregate;

namespace Ecommerce.Location.Features.Countries.UpdateStatus;

internal sealed record UpdateCountryStatusCommand(
    long Id,
    bool IsActive,
    bool IsShippingAvailable,
    bool IsBillingAvailable
) : ICommand;

internal sealed class UpdateCountryStatusHandler(IRepository<Country> repository)
    : ICommandHandler<UpdateCountryStatusCommand>
{
    public async Task<Result> Handle(
        UpdateCountryStatusCommand request,
        CancellationToken cancellationToken
    )
    {
        var country = await repository.GetByIdAsync(request.Id, cancellationToken);

        if (country is null)
        {
            return Result.NotFound();
        }

        country.UpdateStatus(
            request.IsActive,
            request.IsShippingAvailable,
            request.IsBillingAvailable
        );

        await repository.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }
}
