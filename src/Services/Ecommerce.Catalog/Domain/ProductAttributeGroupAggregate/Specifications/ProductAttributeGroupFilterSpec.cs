namespace Ecommerce.Catalog.Domain.ProductAttributeGroupAggregate.Specifications;

public sealed class ProductAttributeGroupFilterSpec : Specification<ProductAttributeGroup>
{
    public ProductAttributeGroupFilterSpec(int pageIndex, int pageSize)
    {
        Query.Skip((pageIndex - 1) * pageSize).Take(pageSize);
    }
}
