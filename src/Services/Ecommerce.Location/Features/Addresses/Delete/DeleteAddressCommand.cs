using Ecommerce.Location.Domain.AddressAggregate;

namespace Ecommerce.Location.Features.Addresses.Delete;

internal sealed record DeleteAddressCommand(Guid Id) : ICommand;

internal sealed class DeleteAddressHandler(IRepository<Address> repository)
    : ICommandHandler<DeleteAddressCommand>
{
    public async Task<Result> Handle(
        DeleteAddressCommand request,
        CancellationToken cancellationToken
    )
    {
        var address = await repository.GetByIdAsync(request.Id, cancellationToken);

        if (address is null)
        {
            return Result.NotFound();
        }

        await repository.DeleteAsync(address, cancellationToken);

        return Result.Success();
    }
}
