using Ecommerce.Location.Domain.CountryAggregate;
using Ecommerce.Location.Domain.CountryAggregate.Specifications;

namespace Ecommerce.Location.Features.Countries.ListPagination;

internal sealed record ListCountriesPaginationQuery(PaginationRequest Filter)
    : IQuery<PagedResult<IEnumerable<CountryDto>>>;

internal sealed class ListCountriesPaginationHandler(IReadRepository<Country> repository)
    : IQueryHandler<ListCountriesPaginationQuery, PagedResult<IEnumerable<CountryDto>>>
{
    public async Task<PagedResult<IEnumerable<CountryDto>>> Handle(
        ListCountriesPaginationQuery request,
        CancellationToken cancellationToken
    )
    {
        var filter = request.Filter;

        var countries = await repository.ListAsync(
            new CountryFilterSpec(filter),
            cancellationToken
        );

        var totalRecords = await repository.CountAsync(cancellationToken);

        var totalPages = (int)Math.Ceiling(totalRecords / (double)filter.PageSize);

        PagedInfo pagedInfo = new(filter.PageIndex, filter.PageSize, totalPages, totalRecords);

        return new(pagedInfo, countries.ToCountryDtos());
    }
}
