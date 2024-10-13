using Microsoft.Extensions.DependencyInjection;

namespace Ecommerce.Marten;

public static class Extensions
{
    public static void AddMarten(
        this IHostApplicationBuilder builder,
        string conn,
        Action<StoreOptions>? configureOptions = null,
        bool disableAsyncDaemon = false
    )
    {
        var martenConfig = builder.Configuration.Get<MartenConfigs>() ?? new MartenConfigs();

        builder.AddNpgsqlDataSource(conn);

        var config = builder
            .Services.AddMarten(_ => StoreConfigs.SetStoreOptions(martenConfig, configureOptions))
            .UseNpgsqlDataSource()
            .UseLightweightSessions()
            .ApplyAllDatabaseChangesOnStartup();

        if (!disableAsyncDaemon)
        {
            config
                .OptimizeArtifactWorkflow(TypeLoadMode.Static)
                .AddAsyncDaemon(martenConfig.DaemonMode);
        }

        builder
            .Services.AddOpenTelemetry()
            .WithMetrics(t =>
                t.AddMeter(Telemetry.ActivityName, ActivitySourceProvider.DefaultSourceName)
            )
            .WithTracing(t =>
                t.AddSource(Telemetry.ActivityName, ActivitySourceProvider.DefaultSourceName)
            );
    }
}
