namespace Ecommerce.SharedKernel.Model;

public abstract class Entity : HasDomainEventsBase
{
    public Guid Id { get; set; }
}

public abstract class Entity<TId> : Entity
    where TId : struct, IEquatable<TId>
{
    public new TId Id { get; set; }
}
