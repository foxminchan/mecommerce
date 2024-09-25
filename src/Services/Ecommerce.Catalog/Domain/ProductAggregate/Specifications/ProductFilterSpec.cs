namespace Ecommerce.Catalog.Domain.ProductAggregate.Specifications;

public sealed class ProductFilterSpec : Specification<Product>
{
    public ProductFilterSpec(long attributeId)
    {
        Query.Where(x =>
            !x.IsDeleted && x.ProductAttributes.Any(y => y.AttributeId == attributeId)
        );
    }

    public ProductFilterSpec(Guid id)
    {
        Query.Where(x => x.Id == id && !x.IsDeleted);
    }
}
