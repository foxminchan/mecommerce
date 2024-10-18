using Ecommerce.Location.Domain.AddressAggregate;

namespace Ecommerce.Location.Features.Addresses.Update;

internal sealed record UpdateAddressCommand(
    Guid Id,
    string? Street,
    string? ZipCode,
    long WardOrCommuneId
) : ICommand;

internal sealed class UpdateAddressHandler(IRepository<Address> repository)
    : ICommandHandler<UpdateAddressCommand>
{
    public async Task<Result> Handle(
        UpdateAddressCommand request,
        CancellationToken cancellationToken
    )
    {
        var address = await repository.GetByIdAsync(request.Id, cancellationToken);

        if (address is null)
        {
            return Result.NotFound();
        }

        address.UpdateInformation(request.Street, request.ZipCode, request.WardOrCommuneId);

        await repository.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }
}
