using Ecommerce.Location.Domain.CountryAggregate;

namespace Ecommerce.Location.Features.Countries.Delete;

internal sealed record DeleteCountryCommand(long Id) : ICommand;

internal sealed class DeleteCountryHandler(IRepository<Country> repository)
    : ICommandHandler<DeleteCountryCommand>
{
    public async Task<Result> Handle(
        DeleteCountryCommand request,
        CancellationToken cancellationToken
    )
    {
        var country = await repository.GetByIdAsync(request.Id, cancellationToken);

        if (country is null)
        {
            return Result.NotFound();
        }

        await repository.DeleteAsync(country, cancellationToken);

        return Result.Success();
    }
}
