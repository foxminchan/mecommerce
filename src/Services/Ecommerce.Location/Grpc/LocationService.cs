using Ecommerce.Location.Features.Addresses;
using Ecommerce.Location.Features.Addresses.Create;
using Ecommerce.Location.Features.Addresses.Get;

namespace Ecommerce.Location.Grpc;

internal sealed class LocationService(ISender sender, ILogger<LocationService> logger)
    : Location.LocationBase
{
    [Authorize(Authorization.Policies.Admin)]
    public override async Task<CreateAddressResponse> CreateAddress(
        CreateAddressRequest request,
        ServerCallContext context
    )
    {
        if (logger.IsEnabled(LogLevel.Debug))
        {
            logger.LogDebug(
                "[{Service}] - Begin grpc call {Method}",
                nameof(LocationService),
                nameof(CreateAddress)
            );
        }

        var command = new CreateAddressCommand(
            request.Street,
            request.ZipCode,
            request.WardOrCommuneId
        );

        var result = await sender.Send(command, context.CancellationToken);

        return MapToCreateAddressResponse(result.Value);
    }

    [AllowAnonymous]
    public override async Task<GetAddressResponse> GetAddress(
        GetAddressRequest request,
        ServerCallContext context
    )
    {
        if (logger.IsEnabled(LogLevel.Debug))
        {
            logger.LogDebug(
                "[{Service}] - Begin grpc call {Method}",
                nameof(LocationService),
                nameof(GetAddress)
            );
        }

        var id = Guid.TryParse(request.AddressId, out var addressId) ? addressId : Guid.Empty;

        var result = await sender.Send(new GetAddressQuery(id), context.CancellationToken);

        return result.Status == ResultStatus.NotFound
            ? new()
            : MapToGetAddressResponse(result.Value);
    }

    private static CreateAddressResponse MapToCreateAddressResponse(Guid id)
    {
        return new() { AddressId = id.ToString() };
    }

    private static GetAddressResponse MapToGetAddressResponse(AddressDto address)
    {
        return new()
        {
            Id = address.Id.ToString(),
            Street = address.Street,
            ZipCode = address.ZipCode,
            WardOrCommune = address.WardOrCommune,
            District = address.District,
            StateOrProvince = address.StateOrProvince,
            Country = address.Country,
            Continent = address.Continent,
        };
    }
}
