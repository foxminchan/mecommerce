using Ecommerce.Inventory.Domain.SupplierAggregate;
using Ecommerce.Inventory.Domain.SupplierAggregate.Specifications;

namespace Ecommerce.Inventory.Features.Suppliers.List;

internal sealed record ListSupplierQuery(PaginationWithSearchRequest Filter)
    : IQuery<PagedResult<IEnumerable<SupplierDto>>>;

internal sealed class ListSupplierHandler(
    IReadRepository<Supplier> repository,
    ILocationService locationService
) : IQueryHandler<ListSupplierQuery, PagedResult<IEnumerable<SupplierDto>>>
{
    public async Task<PagedResult<IEnumerable<SupplierDto>>> Handle(
        ListSupplierQuery request,
        CancellationToken cancellationToken
    )
    {
        var filter = request.Filter;

        var suppliers = await repository.ListAsync(
            new SupplierFilterSpec(filter),
            cancellationToken
        );

        var addresses = await suppliers.ToDictionaryAsync(
            supplier => supplier.Id,
            supplier => locationService.GetLocationAsync(supplier.AddressId, cancellationToken),
            cancellationToken
        );

        var totalRecords = await repository.CountAsync(cancellationToken);

        var totalPages = (int)Math.Ceiling(totalRecords / (double)filter.PageSize);

        PagedInfo pagedInfo = new(filter.PageIndex, filter.PageSize, totalPages, totalRecords);

        return new(pagedInfo, suppliers.ToSupplierDtos(addresses));
    }
}
