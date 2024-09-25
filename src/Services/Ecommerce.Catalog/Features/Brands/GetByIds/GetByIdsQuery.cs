using Ecommerce.Catalog.Domain.BrandAggregate;
using Ecommerce.Catalog.Domain.BrandAggregate.Specifications;

namespace Ecommerce.Catalog.Features.Brands.GetByIds;

internal sealed record GetByIdsQuery(long[] Ids) : IQuery<Result<IEnumerable<BrandDto>>>;

internal sealed class GetByIdsHandler(IReadRepository<Brand> repository)
    : IQueryHandler<GetByIdsQuery, Result<IEnumerable<BrandDto>>>
{
    public async Task<Result<IEnumerable<BrandDto>>> Handle(
        GetByIdsQuery request,
        CancellationToken cancellationToken
    )
    {
        var brands = await repository.ListAsync(
            new BrandFilterSpec(request.Ids),
            cancellationToken
        );

        return Result.Success(brands.ToBrandDtos());
    }
}
