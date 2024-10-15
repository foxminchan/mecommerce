namespace Ecommerce.Inventory.Features.Stocks.ReduceStock;

internal sealed record ReduceStockCommand(Guid Id, long Quantity) : ICommand;

internal sealed class ReduceStockHandler(IRepository<Stock> repository)
    : ICommandHandler<ReduceStockCommand>
{
    public async Task<Result> Handle(
        ReduceStockCommand request,
        CancellationToken cancellationToken
    )
    {
        var stock = await repository.GetByIdAsync(request.Id, cancellationToken);

        if (stock is null)
        {
            return Result.NotFound();
        }

        stock.ReduceStock(request.Quantity, "Reduce product stock");

        await repository.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }
}
