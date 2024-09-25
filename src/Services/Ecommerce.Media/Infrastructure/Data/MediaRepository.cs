namespace Ecommerce.Media.Infrastructure.Data;

public sealed class MediaRepository<T>(MediaContext dbContext)
    : RepositoryBase<T>(dbContext),
        IReadRepository<T>,
        IRepository<T>
    where T : class, IAggregateRoot;
