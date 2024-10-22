namespace Ecommerce.Tax.Domain.CategoryAggregate.Specifications;

public sealed class CategoryFilterSpec : Specification<Category>
{
    public CategoryFilterSpec(long id)
    {
        Query.Where(x => x.Id == id && !x.IsDeleted);
    }

    public CategoryFilterSpec(string? name)
    {
        Query.Where(x => !x.IsDeleted);

        if (!string.IsNullOrEmpty(name))
        {
            Query.Where(x => x.Name!.Contains(name));
        }
    }
}
