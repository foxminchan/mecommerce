using Ecommerce.Catalog.Domain.BrandAggregate;
using Ecommerce.Catalog.Domain.BrandAggregate.Specifications;

namespace Ecommerce.Catalog.Features.Brands.List;

internal sealed record ListBrandsQuery(PaginationWithSearchRequest Filter)
    : IQuery<PagedResult<IEnumerable<BrandDto>>>;

internal sealed class ListBrandsHandler(IReadRepository<Brand> repository)
    : IQueryHandler<ListBrandsQuery, PagedResult<IEnumerable<BrandDto>>>
{
    public async Task<PagedResult<IEnumerable<BrandDto>>> Handle(
        ListBrandsQuery request,
        CancellationToken cancellationToken
    )
    {
        var filter = request.Filter;

        var brands = await repository.ListAsync(new BrandFilterSpec(filter), cancellationToken);

        var totalRecords = await repository.CountAsync(cancellationToken);

        var totalPages = (int)Math.Ceiling(totalRecords / (double)filter.PageSize);

        PagedInfo pagedInfo = new(filter.PageIndex, filter.PageSize, totalPages, totalRecords);

        return new(pagedInfo, brands.ToBrandDtos());
    }
}
