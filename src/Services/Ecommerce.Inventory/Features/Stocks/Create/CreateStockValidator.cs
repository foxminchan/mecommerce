namespace Ecommerce.Inventory.Features.Stocks.Create;

internal sealed class CreateStockValidator : AbstractValidator<CreateStockCommand>
{
    public CreateStockValidator()
    {
        RuleFor(x => x.OnHandQty).GreaterThan(0).LessThanOrEqualTo(long.MaxValue);

        RuleFor(x => x.ReservedQty).GreaterThanOrEqualTo(0).LessThanOrEqualTo(x => x.OnHandQty);

        RuleFor(x => x.ProductId).NotNull();

        RuleFor(x => x.WarehouseId).NotNull();

        RuleFor(x => x.ProductVariantId).NotNull();
    }
}
