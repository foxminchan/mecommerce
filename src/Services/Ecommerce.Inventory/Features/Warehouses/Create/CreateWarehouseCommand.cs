using Ecommerce.Inventory.Domain.WarehouseAggregate;

namespace Ecommerce.Inventory.Features.Warehouses.Create;

internal sealed record CreateWarehouseCommand(
    string? Name,
    long Capacity,
    string? Street,
    string? ZipCode,
    long WardOrCommuneId
) : ICommand<Result<long>>;

internal sealed class CreateWarehouseHandler(
    IRepository<Warehouse> repository,
    ILocationService locationService
) : ICommandHandler<CreateWarehouseCommand, Result<long>>
{
    public async Task<Result<long>> Handle(
        CreateWarehouseCommand request,
        CancellationToken cancellationToken
    )
    {
        var address = new CreateAddressRequest
        {
            Street = request.Street,
            ZipCode = request.ZipCode,
            WardOrCommuneId = request.WardOrCommuneId,
        };

        var addressId = await locationService.CreateLocationAsync(address, cancellationToken);

        var warehouse = new Warehouse(request.Name, request.Capacity, addressId);

        var result = await repository.AddAsync(warehouse, cancellationToken);

        return result.Id;
    }
}
