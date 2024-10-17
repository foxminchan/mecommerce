using Ecommerce.Location.Domain.AddressAggregate;

namespace Ecommerce.Location.Features.Addresses.Get;

internal sealed record GetAddressQuery(Guid Id) : IQuery<Result<AddressDto>>;

internal sealed class GetAddressQueryHandler(IReadRepository<Address> repository)
    : IQueryHandler<GetAddressQuery, Result<AddressDto>>
{
    public async Task<Result<AddressDto>> Handle(
        GetAddressQuery request,
        CancellationToken cancellationToken
    )
    {
        var address = await repository.GetByIdAsync(request.Id, cancellationToken);

        if (address is null)
        {
            return Result.NotFound();
        }

        return address.ToAddressDto();
    }
}
