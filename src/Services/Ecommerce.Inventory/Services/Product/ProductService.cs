using GrpcCatalogClient = Ecommerce.Catalog.Grpc.Product.ProductClient;

namespace Ecommerce.Inventory.Services.Product;

public sealed class ProductService(GrpcCatalogClient client, ILogger<ProductService> logger)
    : IProductService
{
    public async Task<GetProductInfoResponse> GetProductInfoAsync(
        Guid productId,
        CancellationToken cancellationToken = default
    )
    {
        if (logger.IsEnabled(LogLevel.Debug))
        {
            logger.LogDebug(
                "[{Service}] - Begin grpc call {Method}",
                nameof(ProductService),
                nameof(GetProductInfoAsync)
            );
        }

        var response = await client.GetProductInfoAsync(
            new() { ProductId = productId.ToString() },
            cancellationToken: cancellationToken
        );

        return response;
    }
}
