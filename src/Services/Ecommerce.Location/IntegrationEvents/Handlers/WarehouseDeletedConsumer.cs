using Ecommerce.Contracts;
using Ecommerce.Location.Features.Addresses.Delete;

namespace Ecommerce.Location.IntegrationEvents.Handlers;

internal sealed class WarehouseDeletedConsumer(
    ISender sender,
    ILogger<WarehouseDeletedConsumer> logger
) : IConsumer<WarehouseDeletedIntegrationEvent>
{
    public async Task Consume(ConsumeContext<WarehouseDeletedIntegrationEvent> context)
    {
        if (logger.IsEnabled(LogLevel.Information))
        {
            logger.LogInformation(
                "[{Consumer}] - Consuming event: {Event}",
                nameof(WarehouseDeletedConsumer),
                context.Message
            );
        }

        await sender.Send(new DeleteAddressCommand(context.Message.AddressId));
    }
}

internal sealed class WarehouseDeletedConsumerDefinition
    : ConsumerDefinition<WarehouseDeletedConsumer>
{
    public WarehouseDeletedConsumerDefinition()
    {
        Endpoint(x => x.Name = "warehouse-deleted");
        ConcurrentMessageLimit = 1;
    }

    protected override void ConfigureConsumer(
        IReceiveEndpointConfigurator endpointConfigurator,
        IConsumerConfigurator<WarehouseDeletedConsumer> consumerConfigurator,
        IRegistrationContext context
    )
    {
        consumerConfigurator.UseCircuitBreaker(x =>
        {
            x.TrackingPeriod = TimeSpan.FromMinutes(1);
            x.TripThreshold = 15;
            x.ActiveThreshold = 10;
            x.ResetInterval = TimeSpan.FromMinutes(5);
        });
    }
}
