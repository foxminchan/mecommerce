namespace Ecommerce.MassTransit;

[ExcludeFromTopology]
public abstract class IntegrationEvent
{
    public Guid EventId { get; protected set; } = Guid.NewGuid();
    public DateTime DateOccurred { get; protected set; } = DateTime.UtcNow;
    public string? EventType => GetType().AssemblyQualifiedName;
}
