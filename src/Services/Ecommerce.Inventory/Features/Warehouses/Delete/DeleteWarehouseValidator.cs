using Ecommerce.Inventory.Domain.WarehouseAggregate;
using Ecommerce.Inventory.Domain.WarehouseAggregate.Specifications;

namespace Ecommerce.Inventory.Features.Warehouses.Delete;

internal sealed class DeleteWarehouseValidator : AbstractValidator<DeleteWarehouseCommand>
{
    private readonly IReadRepository<Warehouse> _repository;

    public DeleteWarehouseValidator(IReadRepository<Warehouse> repository)
    {
        _repository = repository;

        RuleFor(x => x.Id)
            .MustAsync(NotHaveAnyStock)
            .WithMessage("Warehouse has stock, cannot be deleted.");
    }

    private async Task<bool> NotHaveAnyStock(long id, CancellationToken cancellationToken)
    {
        var warehouse = await _repository.FirstOrDefaultAsync(
            new WarehouseFilterSpec(id),
            cancellationToken
        );
        return warehouse is not null;
    }
}
