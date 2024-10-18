namespace Ecommerce.Inventory.Features.Suppliers.Delete;

internal sealed record DeleteSupplierCommand(long Id) : ICommand;

[TxScope]
internal sealed class DeleteSupplierHandler(IDeleteSupplierService deleteSupplierService)
    : ICommandHandler<DeleteSupplierCommand>
{
    public async Task<Result> Handle(
        DeleteSupplierCommand request,
        CancellationToken cancellationToken
    )
    {
        return await deleteSupplierService.DeleteSupplierAsync(request.Id, cancellationToken);
    }
}
