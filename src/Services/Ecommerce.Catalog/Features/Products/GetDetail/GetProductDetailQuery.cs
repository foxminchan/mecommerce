using Ecommerce.Catalog.Domain.ProductAggregate;
using Ecommerce.Catalog.Domain.ProductAggregate.Specifications;

namespace Ecommerce.Catalog.Features.Products.GetDetail;

internal sealed record GetProductDetailQuery(Guid Id) : IQuery<Result<ProductDetailDto>>;

internal sealed class GetProductDetailHandler(
    IRepository<Product> repository,
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

        var thumbnailTask = mediaService.GetImageAsync(product.ThumbnailId, cancellationToken);

        var productImages = product.ProductImages.Select(x => x.ImageId).ToList();

        var productImageTasks = productImages
            .Select(x => mediaService.GetImageAsync(x, cancellationToken))
            .ToList();

        await Task.WhenAll(thumbnailTask, Task.WhenAll(productImageTasks));

        var thumbnailUrl = thumbnailTask.Result;
        var productImageDto = productImageTasks
            .Select(x => x.Result)
            .Where(x => x is not null)
            .Select(x => x!)
            .ToList();

        return product.ToProductDetailDto(thumbnailUrl?.Url, productImageDto);
    }
}
