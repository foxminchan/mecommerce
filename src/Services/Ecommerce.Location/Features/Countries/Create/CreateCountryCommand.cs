using Ecommerce.Location.Domain.CountryAggregate;

namespace Ecommerce.Location.Features.Countries.Create;

internal sealed record CreateCountryCommand(
    string? Name,
    string? FirstCode,
    string? SecondCode,
    string? ThirdCode,
    Continent Continent,
    bool IsActive,
    bool IsShippingAvailable,
    bool IsBillingAvailable
) : ICommand<Result<long>>;

internal sealed class CreateCountryHandler(IRepository<Country> repository)
    : ICommandHandler<CreateCountryCommand, Result<long>>
{
    public async Task<Result<long>> Handle(
        CreateCountryCommand request,
        CancellationToken cancellationToken
    )
    {
        var country = new Country(
            request.Name,
            request.FirstCode,
            request.SecondCode,
            request.ThirdCode,
            request.Continent,
            request.IsActive,
            request.IsShippingAvailable,
            request.IsBillingAvailable
        );

        var result = await repository.AddAsync(country, cancellationToken);

        return result.Id;
    }
}
