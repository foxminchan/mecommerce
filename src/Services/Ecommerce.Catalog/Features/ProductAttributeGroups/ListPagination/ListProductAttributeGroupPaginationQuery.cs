using Ecommerce.Catalog.Domain.ProductAttributeGroupAggregate;
using Ecommerce.Catalog.Domain.ProductAttributeGroupAggregate.Specifications;

namespace Ecommerce.Catalog.Features.ProductAttributeGroups.ListPagination;

internal sealed record ListProductAttributeGroupPaginationQuery(PaginationRequest Filter)
    : IQuery<PagedResult<IEnumerable<ProductAttributeGroupDto>>>;

internal sealed class ListProductAttributeGroupPaginationHandler(
    IReadRepository<ProductAttributeGroup> repository
)
    : IQueryHandler<
        ListProductAttributeGroupPaginationQuery,
        PagedResult<IEnumerable<ProductAttributeGroupDto>>
    >
{
    public async Task<PagedResult<IEnumerable<ProductAttributeGroupDto>>> Handle(
        ListProductAttributeGroupPaginationQuery request,
        CancellationToken cancellationToken
    )
    {
        var filter = request.Filter;

        var spec = new ProductAttributeGroupFilterSpec(filter.PageIndex, filter.PageSize);

        var productAttributeGroups = await repository.ListAsync(spec, cancellationToken);

        var totalRecords = await repository.CountAsync(cancellationToken);

        var totalPages = (int)Math.Ceiling(totalRecords / (double)filter.PageSize);

        PagedInfo pagedInfo = new(filter.PageIndex, filter.PageSize, totalPages, totalRecords);

        return new(pagedInfo, productAttributeGroups.ToProductAttributeGroupDtos());
    }
}
