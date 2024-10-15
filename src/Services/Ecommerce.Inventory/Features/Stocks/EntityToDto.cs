namespace Ecommerce.Inventory.Features.Stocks;

public static class EntityToDto
{
    public static StockDto ToStockDto(this Stock stock, GetProductInfoResponse? productInfo)
    {
        var availableQty = stock.OnHandQty - stock.ReservedQty;

        var sku = productInfo?.Skus.FirstOrDefault(s => s.Key == stock.ProductVariantId).Value;

        return new(
            stock.Id,
            stock.ProductId,
            productInfo?.Name,
            sku,
            stock.OnHandQty,
            stock.ReservedQty,
            availableQty,
            stock.WarehouseId,
            stock.SupplierId
        );
    }
}
