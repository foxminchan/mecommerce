namespace Ecommerce.MassTransit;

public static class Extensions
{
    public static IHostApplicationBuilder AddRabbitMqEventBus(
        this IHostApplicationBuilder builder,
        Type type,
        Action<IBusRegistrationConfigurator>? configure = null
    )
    {
        var messaging = builder.Configuration.GetConnectionString("event-bus");

        if (string.IsNullOrWhiteSpace(messaging))
        {
            return builder;
        }

        var assembly = type.Assembly;

        builder.Services.AddMassTransit(config =>
        {
            config.SetKebabCaseEndpointNameFormatter();

            config.AddConsumers(assembly);
            config.AddSagaStateMachines(assembly);
            config.AddSagas(assembly);
            config.AddActivities(assembly);

            config.UsingRabbitMq(
                (context, configurator) =>
                {
                    configurator.Host(new Uri(messaging));
                    configurator.ConfigureEndpoints(context);
                    configurator.UseMessageRetry(AddRetryConfiguration);

                    configurator.UseSendFilter(typeof(SendFilter<>), context);
                    configurator.UsePublishFilter(typeof(PublishFilter<>), context);
                    configurator.UseConsumeFilter(typeof(ConsumeFilter<>), context);
                }
            );

            configure?.Invoke(config);
        });

        builder
            .Services.AddOpenTelemetry()
            .WithMetrics(metrics =>
            {
                metrics
                    .AddMeter(InstrumentationOptions.MeterName)
                    .AddMeter(ActivitySourceProvider.DefaultSourceName);
            })
            .WithTracing(tracing =>
            {
                tracing
                    .AddSource(DiagnosticHeaders.DefaultListenerName)
                    .AddSource(ActivitySourceProvider.DefaultSourceName);
            });

        return builder;
    }

    private static void AddRetryConfiguration(IRetryConfigurator retryConfigurator)
    {
        retryConfigurator
            .Exponential(
                3,
                TimeSpan.FromMilliseconds(200),
                TimeSpan.FromMinutes(120),
                TimeSpan.FromMilliseconds(200)
            )
            .Ignore<ValidationException>();
    }
}
