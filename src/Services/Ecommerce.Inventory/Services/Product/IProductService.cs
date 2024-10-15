namespace Ecommerce.Inventory.Services.Product;

public interface IProductService
{
    Task<GetProductInfoResponse> GetProductInfoAsync(
        Guid productId,
        CancellationToken cancellationToken = default
    );
}
