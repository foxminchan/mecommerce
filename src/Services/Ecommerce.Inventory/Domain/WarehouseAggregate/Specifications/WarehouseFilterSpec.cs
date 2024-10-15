namespace Ecommerce.Inventory.Domain.WarehouseAggregate.Specifications;

public sealed class WarehouseFilterSpec : Specification<Warehouse>
{
    public WarehouseFilterSpec(long id)
    {
        Query.Where(x => x.Id == id && x.Stocks.Count != 0);
    }

    public WarehouseFilterSpec(PaginationWithSearchRequest request)
    {
        if (!string.IsNullOrEmpty(request.Search))
        {
            Query.Where(x => x.Name!.Contains(request.Search));
        }

        Query.Skip((request.PageIndex - 1) * request.PageSize).Take(request.PageSize);
    }
}
