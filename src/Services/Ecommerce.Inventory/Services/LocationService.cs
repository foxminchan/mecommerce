using GrpcLocationClient = Ecommerce.Location.Grpc.Location.LocationClient;

namespace Ecommerce.Inventory.Services;

public sealed class LocationService(GrpcLocationClient client, ILogger<LocationService> logger)
    : ILocationService
{
    public async Task<Guid> CreateLocationAsync(
        CreateAddressRequest request,
        CancellationToken cancellationToken = default
    )
    {
        if (logger.IsEnabled(LogLevel.Debug))
        {
            logger.LogDebug(
                "[{Service}] - Begin grpc call {Method}",
                nameof(LocationService),
                nameof(CreateLocationAsync)
            );
        }

        var response = await client.CreateAddressAsync(
            request,
            cancellationToken: cancellationToken
        );

        var id = Guid.TryParse(response.AddressId, out var addressId) ? addressId : Guid.Empty;

        return id;
    }
}
