using Ecommerce.Catalog.Domain.ProductAttributeAggregate;

namespace Ecommerce.Catalog.Features.ProductAttributes.List;

internal sealed record ListProductAttributeQuery : IQuery<Result<IEnumerable<ProductAttributeDto>>>;

internal sealed class ListProductAttributeHandler(IReadRepository<ProductAttribute> repository)
    : IQueryHandler<ListProductAttributeQuery, Result<IEnumerable<ProductAttributeDto>>>
{
    public async Task<Result<IEnumerable<ProductAttributeDto>>> Handle(
        ListProductAttributeQuery request,
        CancellationToken cancellationToken = default
    )
    {
        var productAttributes = await repository.ListAsync(cancellationToken);

        return Result.Success(productAttributes.ToProductAttributeDtos());
    }
}
