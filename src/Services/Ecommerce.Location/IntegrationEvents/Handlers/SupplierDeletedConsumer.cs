using Ecommerce.Contracts;
using Ecommerce.Location.Features.Addresses.Delete;

namespace Ecommerce.Location.IntegrationEvents.Handlers;

internal sealed class SupplierDeletedConsumer(
    ISender sender,
    ILogger<SupplierDeletedConsumer> logger
) : IConsumer<SupplierDeletedIntegrationEvent>
{
    public async Task Consume(ConsumeContext<SupplierDeletedIntegrationEvent> context)
    {
        if (logger.IsEnabled(LogLevel.Information))
        {
            logger.LogInformation(
                "[{Consumer}] - Consuming event: {Event}",
                nameof(SupplierDeletedConsumer),
                context.Message
            );
        }

        await sender.Send(new DeleteAddressCommand(context.Message.AddressId));
    }
}

internal sealed class SupplierDeletedConsumerDefinition
    : ConsumerDefinition<SupplierDeletedConsumer>
{
    public SupplierDeletedConsumerDefinition()
    {
        Endpoint(x => x.Name = "supplier-deleted");
        ConcurrentMessageLimit = 1;
    }

    protected override void ConfigureConsumer(
        IReceiveEndpointConfigurator endpointConfigurator,
        IConsumerConfigurator<SupplierDeletedConsumer> consumerConfigurator,
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
