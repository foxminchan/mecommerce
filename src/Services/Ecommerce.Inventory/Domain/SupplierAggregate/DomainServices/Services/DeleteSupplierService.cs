namespace Ecommerce.Inventory.Domain.SupplierAggregate.DomainServices.Services;

public sealed class DeleteSupplierService(
    IRepository<Supplier> repository,
    ILogger<DeleteSupplierService> logger
) : IDeleteSupplierService
{
    public async Task<Result> DeleteSupplierAsync(
        long id,
        CancellationToken cancellationToken = default
    )
    {
        if (logger.IsEnabled(LogLevel.Information))
        {
            logger.LogInformation(
                "[{DomainService}] Deleting supplier with id: {Id}",
                nameof(DeleteSupplierService),
                id
            );
        }

        var supplier = await repository.GetByIdAsync(id, cancellationToken);

        if (supplier is null)
        {
            return Result.NotFound();
        }

        supplier.Delete();
        await repository.DeleteAsync(supplier, cancellationToken);

        return Result.Success();
    }
}
