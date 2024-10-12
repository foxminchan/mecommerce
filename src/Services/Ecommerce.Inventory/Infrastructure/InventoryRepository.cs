namespace Ecommerce.Inventory.Infrastructure;

public sealed class InventoryRepository<T>(InventoryContext dbContext)
    : RepositoryBase<T>(dbContext),
        IReadRepository<T>,
        IRepository<T>
    where T : class, IAggregateRoot;
