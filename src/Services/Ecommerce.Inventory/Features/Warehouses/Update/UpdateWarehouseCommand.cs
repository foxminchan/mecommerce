using Ecommerce.Inventory.Domain.WarehouseAggregate;

namespace Ecommerce.Inventory.Features.Warehouses.Update;

internal sealed record UpdateWarehouseCommand(
    long Id,
    string? Name,
    long Capacity,
    string? Street,
    string? ZipCode,
    long WardOrCommuneId
) : ICommand;

[TxScope]
internal sealed class UpdateWarehouseHandler(IRepository<Warehouse> repository)
    : ICommandHandler<UpdateWarehouseCommand>
{
    public async Task<Result> Handle(
        UpdateWarehouseCommand request,
        CancellationToken cancellationToken
    )
    {
        var warehouse = await repository.GetByIdAsync(request.Id, cancellationToken);

        if (warehouse is null)
        {
            return Result.NotFound();
        }

        warehouse.UpdateInformation(
            request.Name,
            request.Capacity,
            request.Street,
            request.ZipCode,
            request.WardOrCommuneId
        );
        await repository.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }
}
