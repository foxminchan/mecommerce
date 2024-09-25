using Ecommerce.Catalog.Domain.ProductAttributeGroupAggregate;

namespace Ecommerce.Catalog.Features.ProductAttributeGroups.List;

internal sealed record ListProductAttributeGroupQuery
    : IQuery<Result<IEnumerable<ProductAttributeGroupDto>>>;

internal class ListProductAttributeGroupHandler(IReadRepository<ProductAttributeGroup> repository)
    : IQueryHandler<ListProductAttributeGroupQuery, Result<IEnumerable<ProductAttributeGroupDto>>>
{
    public async Task<Result<IEnumerable<ProductAttributeGroupDto>>> Handle(
        ListProductAttributeGroupQuery request,
        CancellationToken cancellationToken
    )
    {
        var productAttributeGroups = await repository.ListAsync(cancellationToken);

        return Result.Success(productAttributeGroups.ToProductAttributeGroupDtos());
    }
}
