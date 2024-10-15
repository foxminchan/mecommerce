using Ecommerce.Catalog.Features.Products.GetInfo;

namespace Ecommerce.Catalog.Grpc;

internal sealed class ProductService(ISender sender, ILogger<ProductService> logger)
    : Product.ProductBase
{
    [AllowAnonymous]
    public override async Task<GetProductInfoResponse> GetProductInfo(
        GetProductInfoRequest request,
        ServerCallContext context
    )
    {
        if (logger.IsEnabled(LogLevel.Debug))
        {
            logger.LogDebug(
                "[{Service}] - Begin grpc call {Method}",
                nameof(ProductService),
                nameof(GetProductInfo)
            );
        }

        var id = Guid.TryParse(request.ProductId, out var productId) ? productId : Guid.Empty;

        var result = await sender.Send(new GetProductInfoQuery(id), context.CancellationToken);

        return result.Status == ResultStatus.NotFound
            ? new()
            : MapToGetProductInfoResponse(result.Value);
    }

    private static GetProductInfoResponse MapToGetProductInfoResponse(ProductInfoDto productInfo)
    {
        return new()
        {
            ProductId = productInfo.ToString(),
            Name = productInfo.Name,
            Skus = { productInfo.Skus },
        };
    }
}
