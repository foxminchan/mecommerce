using Ecommerce.Catalog.Domain.ProductAggregate;
using Ecommerce.Catalog.Domain.ProductAggregate.Specifications;

namespace Ecommerce.Catalog.Features.Products.ListRelated;

internal sealed record ListProductsRelatedQuery(Guid Id, PaginationRequest Filter)
    : IQuery<PagedResult<IEnumerable<ProductListDto>>>;

internal sealed class ListProductsRelatedHandler(
    IReadRepository<Product> repository,
    IMediaService mediaService
) : IQueryHandler<ListProductsRelatedQuery, PagedResult<IEnumerable<ProductListDto>>>
{
    public async Task<PagedResult<IEnumerable<ProductListDto>>> Handle(
        ListProductsRelatedQuery request,
        CancellationToken cancellationToken
    )
    {
        var filter = request.Filter;

        var products = await repository.ListAsync(
            new ProductFilterSpec(request.Id, filter),
            cancellationToken
        );

        var imageTasks = products
            .Select(async product =>
            {
                var image = await mediaService.GetImageAsync(
                    product.ThumbnailId,
                    cancellationToken
                );
                return (product.Id, image?.Url);
            })
            .ToList();

        var productImages = await Task.WhenAll(imageTasks);

        var productImagesDict = productImages.ToDictionary(x => x.Id, x => x.Url);

        var totalRecords = await repository.CountAsync(
            new ProductFilterSpec(request.Id),
            cancellationToken
        );

        var totalPages = (int)Math.Ceiling(totalRecords / (double)filter.PageSize);

        PagedInfo pagedInfo = new(filter.PageIndex, filter.PageSize, totalPages, totalRecords);

        return new(pagedInfo, products.ToProductListDtos(productImagesDict));
    }
}
