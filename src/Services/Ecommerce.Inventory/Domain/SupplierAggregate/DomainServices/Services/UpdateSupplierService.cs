namespace Ecommerce.Inventory.Domain.SupplierAggregate.DomainServices.Services;

public sealed class UpdateSupplierService(
    IRepository<Supplier> repository,
    ILogger<UpdateSupplierService> logger
) : IUpdateSupplierService
{
    public async Task<Result> UpdateSupplierAsync(
        long id,
        string? name,
        string? email,
        string? phone,
        string? street,
        string? zipCode,
        long wardOrCommuneId,
        CancellationToken cancellationToken = default
    )
    {
        if (logger.IsEnabled(LogLevel.Information))
        {
            logger.LogInformation(
                "[{DomainService}] Updating supplier with id: {Id}",
                nameof(UpdateSupplierService),
                id
            );
        }

        var supplier = await repository.GetByIdAsync(id, cancellationToken);

        if (supplier is null)
        {
            return Result.NotFound();
        }

        supplier.UpdateInformation(name, email, phone, street, zipCode, wardOrCommuneId);
        await repository.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }
}
