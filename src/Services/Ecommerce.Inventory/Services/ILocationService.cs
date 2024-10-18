namespace Ecommerce.Inventory.Services;

public interface ILocationService
{
    Task<Guid> CreateLocationAsync(
        CreateAddressRequest request,
        CancellationToken cancellationToken = default
    );

    Task<GetAddressResponse> GetLocationAsync(
        Guid addressId,
        CancellationToken cancellationToken = default
    );
}
