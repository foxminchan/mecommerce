using Ecommerce.Location.Domain.DistrictAggregate;
using Ecommerce.Location.Domain.DistrictAggregate.Specifications;

namespace Ecommerce.Location.Features.Districts.ListPagination;

internal sealed record ListDistrictsPaginationQuery(ListDistrictsRequest Filter)
    : IQuery<PagedResult<IEnumerable<DistrictDto>>>;

internal sealed class ListDistrictsPaginationHandler(IReadRepository<District> repository)
    : IQueryHandler<ListDistrictsPaginationQuery, PagedResult<IEnumerable<DistrictDto>>>
{
    public async Task<PagedResult<IEnumerable<DistrictDto>>> Handle(
        ListDistrictsPaginationQuery request,
        CancellationToken cancellationToken
    )
    {
        var filter = request.Filter;

        var districts = await repository.ListAsync(
            new DistrictFilterSpec(filter),
            cancellationToken
        );

        var totalRecords = await repository.CountAsync(cancellationToken);

        var totalPages = (int)Math.Ceiling(totalRecords / (double)filter.PageSize);

        PagedInfo pagedInfo = new(filter.PageIndex, filter.PageSize, totalPages, totalRecords);

        return new(pagedInfo, districts.ToDistrictDtos());
    }
}
