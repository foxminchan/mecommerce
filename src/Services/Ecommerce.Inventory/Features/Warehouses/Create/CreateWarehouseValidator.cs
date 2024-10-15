namespace Ecommerce.Inventory.Features.Warehouses.Create;

internal sealed class CreateWarehouseValidator : AbstractValidator<CreateWarehouseCommand>
{
    public CreateWarehouseValidator()
    {
        RuleFor(x => x.Name).NotEmpty().MaximumLength(DataSchemaLength.ExtraLarge);

        RuleFor(x => x.Capacity).GreaterThanOrEqualTo(100).LessThanOrEqualTo(long.MaxValue);

        RuleFor(x => x.Street).NotEmpty().MaximumLength(DataSchemaLength.SuperLarge);

        RuleFor(x => x.ZipCode).NotEmpty().MaximumLength(DataSchemaLength.Small);

        RuleFor(x => x.WardOrCommuneId).NotEmpty();
    }
}
