namespace Ecommerce.Location.Infrastructure;

public sealed class LocationRepository<T>(LocationContext dbContext)
    : RepositoryBase<T>(dbContext),
        IReadRepository<T>,
        IRepository<T>
    where T : class, IAggregateRoot;
