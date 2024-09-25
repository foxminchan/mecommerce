namespace Ecommerce.SharedKernel.Model;

public abstract class Event : INotification
{
    public DateTime DateOccurred { get; protected set; } = DateTime.UtcNow;
}
