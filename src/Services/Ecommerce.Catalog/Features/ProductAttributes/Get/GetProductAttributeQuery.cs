using Ecommerce.Catalog.Domain.ProductAttributeAggregate;

namespace Ecommerce.Catalog.Features.ProductAttributes.Get;

internal sealed record GetProductAttributeQuery(long Id) : IQuery<Result<ProductAttributeDto>>;

internal sealed class GetProductAttributeHandler(IReadRepository<ProductAttribute> repository)
    : IQueryHandler<GetProductAttributeQuery, Result<ProductAttributeDto>>
{
    public async Task<Result<ProductAttributeDto>> Handle(
        GetProductAttributeQuery request,
        CancellationToken cancellationToken
    )
    {
        var productAttribute = await repository.GetByIdAsync(request.Id, cancellationToken);

        Guard.Against.NotFound(request.Id, productAttribute);

        return productAttribute.ToProductAttributeDto();
    }
}
