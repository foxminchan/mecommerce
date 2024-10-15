namespace Ecommerce.Contracts;

public sealed class OrderCompletedIntegrationEvent(
    Guid orderId,
    Dictionary<Guid, long> productQty,
    string? email
) : IntegrationEvent
{
    public Guid OrderId { get; init; } = Guard.Against.Default(orderId);
    public Dictionary<Guid, long> ProductQty { get; init; } = Guard.Against.Null(productQty);
    public string? Email { get; init; } = Guard.Against.Null(email);
}
