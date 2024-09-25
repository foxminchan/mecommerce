namespace Ecommerce.SharedKernel.Model;

public abstract class AuditableEntity : Entity
{
    public DateTime CreatedAt { get; set; }
    public DateTime? LastModifiedAt { get; set; }
    public Guid Version { get; set; }
}

public abstract class AuditableEntity<TId> : Entity<TId>
    where TId : struct, IEquatable<TId>
{
    public DateTime CreatedAt { get; set; }
    public DateTime? LastModifiedAt { get; set; }
    public Guid Version { get; set; }
}
