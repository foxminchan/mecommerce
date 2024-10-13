using Ecommerce.Location.Domain.CountryAggregate;

namespace Ecommerce.Location.Features.Countries.Get;

internal sealed record GetCountryQuery(long Id) : IQuery<Result<CountryDto>>;

internal sealed class GetCountryHandler(IReadRepository<Country> repository)
    : IQueryHandler<GetCountryQuery, Result<CountryDto>>
{
    public async Task<Result<CountryDto>> Handle(
        GetCountryQuery request,
        CancellationToken cancellationToken
    )
    {
        var country = await repository.GetByIdAsync(request.Id, cancellationToken);

        if (country is null)
        {
            return Result.NotFound();
        }

        return country.ToCountryDto();
    }
}
