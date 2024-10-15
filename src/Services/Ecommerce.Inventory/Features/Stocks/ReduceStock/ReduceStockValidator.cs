namespace Ecommerce.Inventory.Features.Stocks.ReduceStock;

internal sealed class ReduceStockValidator : AbstractValidator<ReduceStockCommand>
{
    private readonly IReadRepository<Stock> _repository;

    public ReduceStockValidator(IReadRepository<Stock> repository)
    {
        _repository = repository;

        RuleFor(x => x.Id).NotNull();

        RuleFor(x => x.Quantity).GreaterThan(0);

        RuleFor(x => x).MustAsync(StockNotLessThanRequestedQuantity);
    }

    private async Task<bool> StockNotLessThanRequestedQuantity(
        ReduceStockCommand request,
        CancellationToken cancellationToken
    )
    {
        var stock = await _repository.GetByIdAsync(request.Id, cancellationToken);

        if (stock is null)
        {
            return false;
        }

        return stock.OnHandQty >= request.Quantity;
    }
}
