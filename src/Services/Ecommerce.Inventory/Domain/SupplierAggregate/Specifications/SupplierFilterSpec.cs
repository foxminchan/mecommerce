namespace Ecommerce.Inventory.Domain.SupplierAggregate.Specifications;

public sealed class SupplierFilterSpec : Specification<Supplier>
{
    public SupplierFilterSpec(PaginationWithSearchRequest request)
    {
        if (!string.IsNullOrWhiteSpace(request.Search))
        {
            Query.Where(s =>
                s.Name!.Contains(request.Search)
                || s.Email!.Contains(request.Search)
                || s.ContactPersons!.Any(cp =>
                    cp.Name!.Contains(request.Search) || cp.Email!.Contains(request.Search)
                )
            );
        }

        Query.Skip((request.PageIndex - 1) * request.PageSize).Take(request.PageSize);
    }
}
