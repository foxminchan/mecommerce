using Ecommerce.Contracts;
using Ecommerce.Location.Features.Addresses.Update;

namespace Ecommerce.Location.IntegrationEvents.Handlers;

internal sealed class WarehouseUpdatedConsumer(
    ISender sender,
    ILogger<WarehouseUpdatedConsumer> logger
) : IConsumer<WarehouseUpdatedIntegrationEvent>
{
    public async Task Consume(ConsumeContext<WarehouseUpdatedIntegrationEvent> context)
    {
        if (logger.IsEnabled(LogLevel.Information))
        {
            logger.LogInformation(
                "[{Consumer}] - Consuming event: {Event}",
                nameof(WarehouseUpdatedConsumer),
                context.Message.GetType()
            );
        }

        var message = context.Message;

        var command = new UpdateAddressCommand(
            message.AddressId,
            message.Street,
            message.ZipCode,
            message.WardOrCommuneId
        );

        await sender.Send(command);
    }
}

internal sealed class WarehouseUpdatedConsumerDefinition
    : ConsumerDefinition<WarehouseUpdatedConsumer>
{
    public WarehouseUpdatedConsumerDefinition()
    {
        Endpoint(x => x.Name = "warehouse-updated");
        ConcurrentMessageLimit = 1;
    }

    protected override void ConfigureConsumer(
        IReceiveEndpointConfigurator endpointConfigurator,
        IConsumerConfigurator<WarehouseUpdatedConsumer> consumerConfigurator,
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
