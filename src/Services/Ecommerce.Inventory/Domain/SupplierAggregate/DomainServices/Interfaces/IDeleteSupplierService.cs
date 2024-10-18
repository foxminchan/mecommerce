namespace Ecommerce.Inventory.Domain.SupplierAggregate.DomainServices.Interfaces;

public interface IDeleteSupplierService
{
    Task<Result> DeleteSupplierAsync(long id, CancellationToken cancellationToken = default);
}
