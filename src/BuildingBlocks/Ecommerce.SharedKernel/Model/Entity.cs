namespace Ecommerce.SharedKernel.Model;

public abstract class Entity : HasDomainEventsBase
{
    public Guid Id { get; set; }
}

public abstract class Entity<TId> : HasDomainEventsBase
    where TId : struct, IEquatable<TId>
{
    public TId Id { get; set; }
}
