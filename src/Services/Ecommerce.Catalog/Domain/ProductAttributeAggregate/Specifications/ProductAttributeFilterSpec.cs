namespace Ecommerce.Catalog.Domain.ProductAttributeAggregate.Specifications;

public sealed class ProductAttributeFilterSpec : Specification<ProductAttribute>
{
    public ProductAttributeFilterSpec(int pageIndex, int pageSize)
    {
        Query.Skip((pageIndex - 1) * pageSize).Take(pageSize);
    }
}
