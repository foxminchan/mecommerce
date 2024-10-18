using Ecommerce.Inventory.Domain.SupplierAggregate;

namespace Ecommerce.Inventory.Features.Suppliers;

public sealed record SupplierDto(
    string? Name,
    string? Email,
    string? Phone,
    List<ContactPerson>? ContactPersons,
    string? Street,
    string? ZipCode,
    string? WardOrCommune,
    string? District,
    string? StateOrProvince,
    string? Country,
    string? Continent
);
