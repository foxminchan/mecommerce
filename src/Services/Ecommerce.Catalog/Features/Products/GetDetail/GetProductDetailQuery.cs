using Ecommerce.Catalog.Domain.ProductAggregate;
using Ecommerce.Catalog.Domain.ProductAggregate.Specifications;

namespace Ecommerce.Catalog.Features.Products.GetDetail;

internal sealed record GetProductDetailQuery(Guid Id) : IQuery<Result<ProductDetailDto>>;

internal sealed class GetProductDetailHandler(
    IReadRepository<Product> repository,
    IMediaService mediaService
) : IQueryHandler<GetProductDetailQuery, Result<ProductDetailDto>>
{
    public async Task<Result<ProductDetailDto>> Handle(
        GetProductDetailQuery request,
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

        var (thumbnail, productImageDto) = await product.GetFirstAsync(
            item => mediaService.GetImageAsync(item.ThumbnailId, cancellationToken),
            item =>
                item.ProductImages.Select(x =>
                    mediaService.GetImageAsync(x.ImageId, cancellationToken)
                ),
            cancellationToken
        );

        return product.ToProductDetailDto(thumbnail?.Url, productImageDto);
    }
}
