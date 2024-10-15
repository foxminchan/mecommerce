using Ecommerce.Inventory.Domain.WarehouseAggregate;

namespace Ecommerce.Inventory.Features.Warehouses.Delete;

internal sealed record DeleteWarehouseCommand(long Id) : ICommand;

[TxScope]
internal sealed class DeleteWarehouseHandler(IRepository<Warehouse> repository)
    : ICommandHandler<DeleteWarehouseCommand>
{
    public async Task<Result> Handle(
        DeleteWarehouseCommand request,
        CancellationToken cancellationToken
    )
    {
        var warehouse = await repository.GetByIdAsync(request.Id, cancellationToken);

        if (warehouse is null)
        {
            return Result.NotFound();
        }

        warehouse.Delete();
        await repository.DeleteAsync(warehouse, cancellationToken);

        return Result.NoContent();
    }
}
