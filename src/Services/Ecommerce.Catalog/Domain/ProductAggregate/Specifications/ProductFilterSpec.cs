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

    public ProductFilterSpec(ListProductsRequest request)
    {
        if (!string.IsNullOrWhiteSpace(request.Category))
        {
            Query.Where(x => x.ProductCategories.Any(y => y.Category.Slug == request.Category));
        }

        if (!string.IsNullOrWhiteSpace(request.Brand))
        {
            Query.Where(x => x.Brand.Slug == request.Brand);
        }

        if (!string.IsNullOrWhiteSpace(request.Search))
        {
            Query.Where(x => x.SearchVector!.Matches(request.Search));
        }

        Query
            .ApplyPriceRange(request.StartPrice, request.EndPrice)
            .ApplyOrdering(request.SortBy, request.IsDescending)
            .ApplyPaging(request.PageIndex, request.PageSize);
    }
}
