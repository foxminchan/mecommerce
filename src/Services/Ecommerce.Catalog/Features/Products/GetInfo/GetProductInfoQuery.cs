using Ecommerce.Catalog.Domain.ProductAggregate;
using Ecommerce.Catalog.Domain.ProductAggregate.Specifications;

namespace Ecommerce.Catalog.Features.Products.GetInfo;

internal sealed record GetProductInfoQuery(Guid Id) : IQuery<Result<ProductInfoDto>>;

internal sealed class GetProductInfoHandler(IReadRepository<Product> repository)
    : IQueryHandler<GetProductInfoQuery, Result<ProductInfoDto>>
{
    public async Task<Result<ProductInfoDto>> Handle(
        GetProductInfoQuery request,
        CancellationToken cancellationToken
    )
    {
        var product = await repository.FirstOrDefaultAsync(
            new ProductFilterSpec(request.Id),
            cancellationToken
        );

        if (product is null)
        {
            return Result.NotFound();
        }

        return product.ToProductInfoDto();
    }
}
