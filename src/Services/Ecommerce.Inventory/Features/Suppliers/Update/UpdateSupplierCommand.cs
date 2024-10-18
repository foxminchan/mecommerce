namespace Ecommerce.Inventory.Features.Suppliers.Update;

internal sealed record UpdateSupplierCommand(
    long Id,
    string? Name,
    string? Email,
    string? Phone,
    string? Street,
    string? ZipCode,
    long WardOrCommuneId
) : ICommand;

[TxScope]
internal sealed class UpdateSupplierHandler(IUpdateSupplierService updateSupplierService)
    : ICommandHandler<UpdateSupplierCommand>
{
    public async Task<Result> Handle(
        UpdateSupplierCommand request,
        CancellationToken cancellationToken
    )
    {
        return await updateSupplierService.UpdateSupplierAsync(
            request.Id,
            request.Name,
            request.Email,
            request.Phone,
            request.Street,
            request.ZipCode,
            request.WardOrCommuneId,
            cancellationToken
        );
    }
}
