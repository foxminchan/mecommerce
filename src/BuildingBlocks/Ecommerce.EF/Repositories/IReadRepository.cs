namespace Ecommerce.EF.Repositories;

public interface IReadRepository<T> : IReadRepositoryBase<T>
    where T : class, IAggregateRoot;
