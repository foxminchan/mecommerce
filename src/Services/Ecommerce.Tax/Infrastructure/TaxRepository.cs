namespace Ecommerce.Tax.Infrastructure;

public sealed class TaxRepository<T>(TaxContext dbContext)
    : RepositoryBase<T>(dbContext),
        IReadRepository<T>,
        IRepository<T>
    where T : class, IAggregateRoot;
