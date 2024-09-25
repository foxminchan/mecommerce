using Ecommerce.Catalog.Domain.ProductAttributeGroupAggregate;

namespace Ecommerce.Catalog.Features.ProductAttributeGroups.Get;

internal sealed record GetProductAttributeGroupQuery(long Id)
    : IQuery<Result<ProductAttributeGroupDto>>;

internal class GetProductAttributeGroupHandler(IReadRepository<ProductAttributeGroup> repository)
    : IQueryHandler<GetProductAttributeGroupQuery, Result<ProductAttributeGroupDto>>
{
    public async Task<Result<ProductAttributeGroupDto>> Handle(
        GetProductAttributeGroupQuery request,
        CancellationToken cancellationToken
    )
    {
        var productAttributeGroup = await repository.GetByIdAsync(request.Id, cancellationToken);

        if (productAttributeGroup is null)
        {
            return Result.NotFound();
        }

        return productAttributeGroup.ToProductAttributeGroupDto();
    }
}
