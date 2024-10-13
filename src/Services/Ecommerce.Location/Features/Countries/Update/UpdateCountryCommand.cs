using Ecommerce.Location.Domain.CountryAggregate;

namespace Ecommerce.Location.Features.Countries.Update;

internal sealed record UpdateCountryCommand(
    long Id,
    string? Name,
    string? FirstCode,
    string? SecondCode,
    string? ThirdCode,
    Continent Continent
) : ICommand;

internal sealed class UpdateCountryHandler(IRepository<Country> repository)
    : ICommandHandler<UpdateCountryCommand>
{
    public async Task<Result> Handle(
        UpdateCountryCommand request,
        CancellationToken cancellationToken
    )
    {
        var country = await repository.GetByIdAsync(request.Id, cancellationToken);

        if (country is null)
        {
            return Result.NotFound();
        }

        country.UpdateInformation(
            request.Name,
            request.FirstCode,
            request.SecondCode,
            request.ThirdCode,
            request.Continent
        );

        await repository.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }
}
