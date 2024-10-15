using Ecommerce.Inventory.Domain.SupplierAggregate;

namespace Ecommerce.Inventory.Features.Suppliers.Create;

internal sealed record CreateSupplierCommand(
    string? Name,
    string? Email,
    string? Phone,
    List<ContactPersonRequest>? ContactPersons,
    string? Street,
    string? ZipCode,
    long WardOrCommuneId
) : ICommand<Result<long>>;

[TxScope]
internal sealed class CreateSupplierHandler(
    IRepository<Supplier> repository,
    ILocationService locationService
) : ICommandHandler<CreateSupplierCommand, Result<long>>
{
    public async Task<Result<long>> Handle(
        CreateSupplierCommand request,
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

        var supplier = new Supplier(
            request.Name,
            request.Email,
            request.Phone,
            request
                .ContactPersons?.Select(x => new ContactPerson(x.Name, x.Email, x.Phone))
                .ToList(),
            addressId
        );

        var result = await repository.AddAsync(supplier, cancellationToken);

        return result.Id;
    }
}
