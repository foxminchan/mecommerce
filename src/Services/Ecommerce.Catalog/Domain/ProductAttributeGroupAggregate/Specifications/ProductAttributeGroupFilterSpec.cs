namespace Ecommerce.Catalog.Domain.ProductAttributeGroupAggregate.Specifications;

public sealed class ProductAttributeGroupFilterSpec : Specification<ProductAttributeGroup>
{
    public ProductAttributeGroupFilterSpec(PaginationRequest request)
    {
        Query.Skip((request.PageIndex - 1) * request.PageSize).Take(request.PageSize);
    }
}
