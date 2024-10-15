namespace Ecommerce.Inventory.Features.Stocks.AddStock;

internal sealed class AddStockValidator : AbstractValidator<AddStockCommand>
{
    public AddStockValidator()
    {
        RuleFor(x => x.Id).NotNull();

        RuleFor(x => x.Quantity).GreaterThan(0);
    }
}
