namespace Ecommerce.Inventory.Features.Stocks.Create;

internal sealed record CreateStockCommand(
    long OnHandQty,
    long ReservedQty,
    Guid ProductId,
    long ProductVariantId,
    long WarehouseId,
    long SupplierId
) : ICommand<Result<Guid>>;

internal sealed class CreateStockHandler(IRepository<Stock> repository)
    : ICommandHandler<CreateStockCommand, Result<Guid>>
{
    public async Task<Result<Guid>> Handle(
        CreateStockCommand request,
        CancellationToken cancellationToken
    )
    {
        var stock = new Stock(
            request.OnHandQty,
            request.ReservedQty,
            request.ProductId,
            request.WarehouseId,
            request.SupplierId,
            request.ProductVariantId
        );

        var result = await repository.AddAsync(stock, cancellationToken);

        return result.Id;
    }
}
