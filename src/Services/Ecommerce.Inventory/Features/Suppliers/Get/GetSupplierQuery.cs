using Ecommerce.Inventory.Domain.SupplierAggregate;

namespace Ecommerce.Inventory.Features.Suppliers.Get;

internal sealed record GetSupplierQuery(long Id) : IQuery<Result<SupplierDto>>;

internal sealed class GetSupplierHandler(
    IReadRepository<Supplier> repository,
    ILocationService locationService
) : IQueryHandler<GetSupplierQuery, Result<SupplierDto>>
{
    public async Task<Result<SupplierDto>> Handle(
        GetSupplierQuery query,
        CancellationToken cancellationToken
    )
    {
        var supplier = await repository.GetByIdAsync(query.Id, cancellationToken);

        if (supplier is null)
        {
            return Result.NotFound();
        }

        var address = await locationService.GetLocationAsync(supplier.AddressId, cancellationToken);

        return supplier.ToSupplierDto(address);
    }
}
