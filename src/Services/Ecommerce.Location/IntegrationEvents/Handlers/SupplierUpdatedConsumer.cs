using Ecommerce.Contracts;
using Ecommerce.Location.Features.Addresses.Update;

namespace Ecommerce.Location.IntegrationEvents.Handlers;

internal sealed class SupplierUpdatedConsumer(
    ISender sender,
    ILogger<SupplierUpdatedConsumer> logger
) : IConsumer<SupplierUpdatedIntegrationEvent>
{
    public async Task Consume(ConsumeContext<SupplierUpdatedIntegrationEvent> context)
    {
        if (logger.IsEnabled(LogLevel.Information))
        {
            logger.LogInformation(
                "[{Consumer}] - Consuming event: {Event}",
                nameof(SupplierUpdatedConsumer),
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

internal sealed class SupplierUpdatedConsumerDefinition
    : ConsumerDefinition<SupplierUpdatedConsumer>
{
    public SupplierUpdatedConsumerDefinition()
    {
        Endpoint(x => x.Name = "supplier-updated");
        ConcurrentMessageLimit = 1;
    }

    protected override void ConfigureConsumer(
        IReceiveEndpointConfigurator endpointConfigurator,
        IConsumerConfigurator<SupplierUpdatedConsumer> consumerConfigurator,
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
