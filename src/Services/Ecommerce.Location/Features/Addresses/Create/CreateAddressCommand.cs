using Ecommerce.Location.Domain.AddressAggregate;

namespace Ecommerce.Location.Features.Addresses.Create;

internal sealed record CreateAddressCommand(string? Street, string? ZipCode, long WardOrCommuneId)
    : ICommand<Result<Guid>>;

internal sealed class CreateAddressHandler(IRepository<Address> repository)
    : ICommandHandler<CreateAddressCommand, Result<Guid>>
{
    public async Task<Result<Guid>> Handle(
        CreateAddressCommand request,
        CancellationToken cancellationToken
    )
    {
        var address = new Address(request.Street, request.ZipCode, request.WardOrCommuneId);

        var result = await repository.AddAsync(address, cancellationToken);

        return result.Id;
    }
}
