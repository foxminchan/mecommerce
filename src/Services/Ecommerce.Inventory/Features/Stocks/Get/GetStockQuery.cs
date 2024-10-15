namespace Ecommerce.Inventory.Features.Stocks.Get;

internal sealed record GetStockQuery(Guid Id) : IQuery<Result<StockDto>>;

internal sealed class GetStockQueryHandler(
    IReadRepository<Stock> repository,
    IProductService productService
) : IQueryHandler<GetStockQuery, Result<StockDto>>
{
    public async Task<Result<StockDto>> Handle(
        GetStockQuery request,
        CancellationToken cancellationToken
    )
    {
        var stock = await repository.GetByIdAsync(request.Id, cancellationToken);

        if (stock is null)
        {
            return Result.NotFound();
        }

        var productInfo = await productService.GetProductInfoAsync(
            stock.ProductId,
            cancellationToken
        );

        return stock.ToStockDto(productInfo);
    }
}
