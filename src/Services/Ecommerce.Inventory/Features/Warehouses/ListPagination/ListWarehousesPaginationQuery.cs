using Ecommerce.Inventory.Domain.WarehouseAggregate;
using Ecommerce.Inventory.Domain.WarehouseAggregate.Specifications;

namespace Ecommerce.Inventory.Features.Warehouses.ListPagination;

internal sealed record ListWarehousesPaginationQuery(PaginationWithSearchRequest Filter)
    : IQuery<PagedResult<IEnumerable<WarehouseDto>>>;

internal sealed class ListWarehousesPaginationHandler(
    IReadRepository<Warehouse> repository,
    ILocationService locationService
) : IQueryHandler<ListWarehousesPaginationQuery, PagedResult<IEnumerable<WarehouseDto>>>
{
    public async Task<PagedResult<IEnumerable<WarehouseDto>>> Handle(
        ListWarehousesPaginationQuery request,
        CancellationToken cancellationToken
    )
    {
        var filter = request.Filter;

        var warehouses = await repository.ListAsync(
            new WarehouseFilterSpec(filter),
            cancellationToken
        );

        var addresses = await warehouses.ToDictionaryAsync(
            x => x.Id,
            x => locationService.GetLocationAsync(x.AddressId, cancellationToken),
            cancellationToken
        );

        var totalRecords = await repository.CountAsync(cancellationToken);

        var totalPages = (int)Math.Ceiling(totalRecords / (double)filter.PageSize);

        PagedInfo pagedInfo = new(filter.PageIndex, filter.PageSize, totalPages, totalRecords);

        return new(pagedInfo, warehouses.ToWarehouseDtos(addresses));
    }
}
