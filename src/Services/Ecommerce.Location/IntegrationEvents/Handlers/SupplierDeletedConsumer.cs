using Ecommerce.Contracts;
using Ecommerce.Location.Domain.AddressAggregate;

namespace Ecommerce.Location.IntegrationEvents.Handlers;

public sealed class SupplierDeletedConsumer(
    IRepository<Address> repository,
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

        var address = await repository.GetByIdAsync(context.Message.AddressId);

        if (address is not null)
        {
            await repository.DeleteAsync(address);
        }
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
