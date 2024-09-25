namespace Ecommerce.SharedKernel.ActivityScope;

/// <summary>
///     ref: https://github.com/oskardudycz/EventSourcing.NetCore/blob/main/Core/OpenTelemetry/ActivityScope.cs
/// </summary>
public sealed record StartActivityOptions
{
    public ActivityKind Kind = ActivityKind.Internal;
    public Dictionary<string, object?> Tags { get; set; } = new();

    public string? ParentId { get; set; }

    public ActivityContext? Parent { get; set; }
}
