using Ecommerce.Catalog.Domain.VariantAggregate;
using Ecommerce.Catalog.Domain.VariantAggregate.Specifications;

namespace Ecommerce.Catalog.Features.Variants.ListPagination;

internal sealed record ListVariantsPaginationQuery(PaginationRequest Filter)
    : IQuery<PagedResult<IEnumerable<VariantDto>>>;

internal sealed class ListVariantsPaginationHandler(IRepository<Variant> repository)
    : IQueryHandler<ListVariantsPaginationQuery, PagedResult<IEnumerable<VariantDto>>>
{
    public async Task<PagedResult<IEnumerable<VariantDto>>> Handle(
        ListVariantsPaginationQuery request,
        CancellationToken cancellationToken
    )
    {
        var filter = request.Filter;

        var spec = new VariantFilterSpec(filter.PageIndex, filter.PageSize);

        var variants = await repository.ListAsync(spec, cancellationToken);

        var totalRecords = await repository.CountAsync(cancellationToken);

        var totalPages = (int)Math.Ceiling(totalRecords / (double)filter.PageSize);

        PagedInfo pagedInfo = new(filter.PageIndex, filter.PageSize, totalPages, totalRecords);

        return new(pagedInfo, variants.ToVariantDtos());
    }
}
