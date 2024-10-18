using Ecommerce.Inventory.Domain.SupplierAggregate;

namespace Ecommerce.Inventory.Features.Suppliers.Delete;

internal sealed record DeleteSupplierCommand(long Id) : ICommand;

[TxScope]
internal sealed class DeleteSupplierHandler(IRepository<Supplier> repository)
    : ICommandHandler<DeleteSupplierCommand>
{
    public async Task<Result> Handle(
        DeleteSupplierCommand request,
        CancellationToken cancellationToken
    )
    {
        var supplier = await repository.GetByIdAsync(request.Id, cancellationToken);

        if (supplier is null)
        {
            return Result.NotFound();
        }

        supplier.Delete();
        await repository.DeleteAsync(supplier, cancellationToken);

        return Result.NoContent();
    }
}
