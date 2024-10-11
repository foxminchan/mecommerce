namespace Ecommerce.Catalog.Domain.ProductAttributeAggregate.Specifications;

public sealed class ProductAttributeFilterSpec : Specification<ProductAttribute>
{
    public ProductAttributeFilterSpec(PaginationRequest request)
    {
        Query.Skip((request.PageIndex - 1) * request.PageSize).Take(request.PageSize);
    }
}
