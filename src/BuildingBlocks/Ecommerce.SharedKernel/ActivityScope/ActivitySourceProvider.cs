namespace Ecommerce.SharedKernel.ActivityScope;

/// <summary>
///     ref: https://github.com/oskardudycz/EventSourcing.NetCore/blob/main/Core/OpenTelemetry/ActivitySourceProvider.cs
/// </summary>
public static class ActivitySourceProvider
{
    public const string DefaultSourceName = "m-ecommerce.net";
    public static readonly ActivitySource Instance = new(DefaultSourceName, "v1");

    public static ActivityListener AddDummyListener(
        ActivitySamplingResult samplingResult = ActivitySamplingResult.AllDataAndRecorded
    )
    {
        var listener = new ActivityListener
        {
            ShouldListenTo = _ => true,
            Sample = (ref ActivityCreationOptions<ActivityContext> _) => samplingResult,
        };

        ActivitySource.AddActivityListener(listener);

        return listener;
    }
}
