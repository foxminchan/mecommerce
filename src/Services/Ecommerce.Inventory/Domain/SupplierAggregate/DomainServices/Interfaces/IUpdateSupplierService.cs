namespace Ecommerce.Inventory.Domain.SupplierAggregate.DomainServices.Interfaces;

public interface IUpdateSupplierService
{
    Task<Result> UpdateSupplierAsync(
        long id,
        string? name,
        string? email,
        string? phone,
        string? street,
        string? zipCode,
        long wardOrCommuneId,
        CancellationToken cancellationToken = default
    );
}
