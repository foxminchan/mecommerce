namespace Ecommerce.EF;

public interface IReadRepository<T> : IReadRepositoryBase<T>
    where T : class, IAggregateRoot;
