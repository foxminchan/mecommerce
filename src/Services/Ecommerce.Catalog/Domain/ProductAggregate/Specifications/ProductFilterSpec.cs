using DbFunctions = Microsoft.EntityFrameworkCore.EF;

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
            var query = DbFunctions.Functions.PhraseToTsQuery("english", request.Search);

            Query
                .Where(x => x.SearchVector!.Matches(query))
                .OrderBy(x => x.SearchVector!.Rank(query));
        }

        if (request.IsFeatured)
        {
            Query.Where(x => x.IsFeatured);
        }

        Query
            .ApplyPriceRange(request.StartPrice, request.EndPrice)
            .ApplyOrdering(request.SortBy, request.IsDescending)
            .ApplyPaging(request.PageIndex, request.PageSize);
    }

    public ProductFilterSpec(Guid id, PaginationRequest request)
    {
        Query
            .Where(x =>
                x.ProductRelateds.Any(y => y.RelatedProductId == id && !y.Product.IsDeleted)
            )
            .ApplyPaging(request.PageIndex, request.PageSize);
    }
}
