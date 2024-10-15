using Ecommerce.Inventory.Domain.SupplierAggregate;

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
internal sealed class UpdateSupplierHandler(IRepository<Supplier> repository)
    : ICommandHandler<UpdateSupplierCommand>
{
    public async Task<Result> Handle(
        UpdateSupplierCommand request,
        CancellationToken cancellationToken
    )
    {
        var supplier = await repository.GetByIdAsync(request.Id, cancellationToken);

        if (supplier is null)
        {
            return Result.NotFound();
        }

        supplier.UpdateInformation(
            request.Name,
            request.Email,
            request.Phone,
            request.Street,
            request.ZipCode,
            request.WardOrCommuneId
        );
        await repository.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }
}
