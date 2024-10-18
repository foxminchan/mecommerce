using Ecommerce.Contracts;
using Ecommerce.Location.Domain.AddressAggregate;

namespace Ecommerce.Location.IntegrationEvents.Handlers;

internal sealed class SupplierUpdatedConsumer(
    IRepository<Address> repository,
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

        var address = await repository.GetByIdAsync(message.AddressId);

        if (address is not null)
        {
            address.UpdateInformation(message.Street, message.ZipCode, message.WardOrCommuneId);

            await repository.SaveChangesAsync();
        }
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
