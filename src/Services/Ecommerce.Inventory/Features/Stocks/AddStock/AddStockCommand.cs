namespace Ecommerce.Inventory.Features.Stocks.AddStock;

internal sealed record AddStockCommand(Guid Id, long Quantity) : ICommand;

internal sealed class AddStockHandler(IRepository<Stock> repository)
    : ICommandHandler<AddStockCommand>
{
    public async Task<Result> Handle(AddStockCommand request, CancellationToken cancellationToken)
    {
        var stock = await repository.GetByIdAsync(request.Id, cancellationToken);

        if (stock is null)
        {
            return Result.NotFound();
        }

        stock.AddStock(request.Quantity, "Add product stock");

        await repository.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }
}
