using Ecommerce.Location.Domain.StateOrProvinceAggregate;
using Ecommerce.Location.Domain.StateOrProvinceAggregate.Specifications;

namespace Ecommerce.Location.Features.StateOrProvinces.ListPagination;

internal sealed record ListStateOrProvincesPaginationQuery(ListStateOrProvincesRequest Filter)
    : IQuery<PagedResult<IEnumerable<StateOrProvinceDto>>>;

internal sealed class ListStateOrProvincesPaginationHandler(
    IReadRepository<StateOrProvince> repository
) : IQueryHandler<ListStateOrProvincesPaginationQuery, PagedResult<IEnumerable<StateOrProvinceDto>>>
{
    public async Task<PagedResult<IEnumerable<StateOrProvinceDto>>> Handle(
        ListStateOrProvincesPaginationQuery request,
        CancellationToken cancellationToken
    )
    {
        var filter = request.Filter;

        var stateOrProvinces = await repository.ListAsync(
            new StateOrProvinceFilterSpec(filter),
            cancellationToken
        );

        var totalRecords = await repository.CountAsync(cancellationToken);

        var totalPages = (int)Math.Ceiling(totalRecords / (double)filter.PageSize);

        PagedInfo pagedInfo = new(filter.PageIndex, filter.PageSize, totalPages, totalRecords);

        return new(pagedInfo, stateOrProvinces.ToStateOrProvinceDtos());
    }
}
