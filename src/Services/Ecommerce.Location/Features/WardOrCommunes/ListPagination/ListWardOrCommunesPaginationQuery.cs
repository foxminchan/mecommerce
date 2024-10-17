using Ecommerce.Location.Domain.WardOrCommuneAggregate;
using Ecommerce.Location.Domain.WardOrCommuneAggregate.Specifications;

namespace Ecommerce.Location.Features.WardOrCommunes.ListPagination;

internal sealed record ListWardOrCommunesPaginationQuery(ListWardOrCommunesRequest Filter)
    : IQuery<PagedResult<IEnumerable<WardOrCommuneDto>>>;

internal sealed class ListWardOrCommunesPaginationHandler(IReadRepository<WardOrCommune> repository)
    : IQueryHandler<ListWardOrCommunesPaginationQuery, PagedResult<IEnumerable<WardOrCommuneDto>>>
{
    public async Task<PagedResult<IEnumerable<WardOrCommuneDto>>> Handle(
        ListWardOrCommunesPaginationQuery request,
        CancellationToken cancellationToken
    )
    {
        var filter = request.Filter;

        var wardOrCommunes = await repository.ListAsync(
            new WardOrCommuneFilterSpec(filter),
            cancellationToken
        );

        var totalRecords = await repository.CountAsync(cancellationToken);

        var totalPages = (int)Math.Ceiling(totalRecords / (double)filter.PageSize);

        PagedInfo pagedInfo = new(filter.PageIndex, filter.PageSize, totalPages, totalRecords);

        return new(pagedInfo, wardOrCommunes.ToWardOrCommuneDtos());
    }
}
