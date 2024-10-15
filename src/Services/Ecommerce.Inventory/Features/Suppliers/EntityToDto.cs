using Ecommerce.Inventory.Domain.SupplierAggregate;

namespace Ecommerce.Inventory.Features.Suppliers;

public static class EntityToDto
{
    public static SupplierDto ToSupplierDto(this Supplier entity, GetAddressResponse? address)
    {
        return new(
            entity.Name,
            entity.Email,
            entity.Phone,
            entity.ContactPersons?.ToList(),
            address?.Street,
            address?.ZipCode,
            address?.WardOrCommune,
            address?.District,
            address?.StateOrProvince,
            address?.Country,
            address?.Continent
        );
    }

    public static IEnumerable<SupplierDto> ToSupplierDtos(
        this IEnumerable<Supplier> entities,
        Dictionary<long, GetAddressResponse?> addresses
    )
    {
        return entities
            .Select(entity =>
            {
                var address = addresses
                    .Where(x => x.Key == entity.Id)
                    .Select(x => x.Value)
                    .FirstOrDefault();

                return entity.ToSupplierDto(address);
            })
            .ToList();
    }
}
