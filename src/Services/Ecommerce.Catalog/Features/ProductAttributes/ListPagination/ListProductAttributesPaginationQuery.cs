using Ecommerce.Catalog.Domain.ProductAttributeAggregate;
using Ecommerce.Catalog.Domain.ProductAttributeAggregate.Specifications;

namespace Ecommerce.Catalog.Features.ProductAttributes.ListPagination;

internal sealed record ListProductAttributesPaginationQuery(PaginationRequest Filter)
    : IQuery<PagedResult<IEnumerable<ProductAttributeDto>>>;

internal sealed class ListProductAttributesPaginationHandler(
    IReadRepository<ProductAttribute> repository
)
    : IQueryHandler<
        ListProductAttributesPaginationQuery,
        PagedResult<IEnumerable<ProductAttributeDto>>
    >
{
    public async Task<PagedResult<IEnumerable<ProductAttributeDto>>> Handle(
        ListProductAttributesPaginationQuery request,
        CancellationToken cancellationToken
    )
    {
        var filter = request.Filter;

        var productAttributes = await repository.ListAsync(
            new ProductAttributeFilterSpec(filter),
            cancellationToken
        );

        var totalRecords = await repository.CountAsync(cancellationToken);

        var totalPages = (int)Math.Ceiling(totalRecords / (double)filter.PageSize);

        PagedInfo pagedInfo = new(filter.PageIndex, filter.PageSize, totalPages, totalRecords);

        return new(pagedInfo, productAttributes.ToProductAttributeDtos());
    }
}
