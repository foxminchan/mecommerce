﻿using Ecommerce.Location.Domain.CountryAggregate;
using Ecommerce.Location.Domain.CountryAggregate.Specifications;

namespace Ecommerce.Location.Features.Countries.List;

internal sealed record ListCountriesQuery(string? Name) : IQuery<Result<IEnumerable<CountryDto>>>;

internal sealed class ListCountriesHandler(IReadRepository<Country> repository)
    : IQueryHandler<ListCountriesQuery, Result<IEnumerable<CountryDto>>>
{
    public async Task<Result<IEnumerable<CountryDto>>> Handle(
        ListCountriesQuery request,
        CancellationToken cancellationToken
    )
    {
        var countries = await repository.ListAsync(
            new CountryFilterSpec(request.Name),
            cancellationToken
        );

        return Result.Success(countries.Select(EntityToDto.ToCountryDto));
    }
}
