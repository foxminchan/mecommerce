using Ecommerce.Catalog.Domain.BrandAggregate;
using Ecommerce.Catalog.Domain.BrandAggregate.Specifications;

namespace Ecommerce.Catalog.Features.Brands.Get;

internal sealed record GetBrandQuery(long Id) : IQuery<Result<BrandDto>>;

internal class GetBrandHandler(IReadRepository<Brand> repository)
    : IQueryHandler<GetBrandQuery, Result<BrandDto>>
{
    public async Task<Result<BrandDto>> Handle(
        GetBrandQuery request,
        CancellationToken cancellationToken
    )
    {
        var brand = await repository.FirstOrDefaultAsync(
            new BrandFilterSpec(request.Id),
            cancellationToken
        );

        if (brand is null)
        {
            return Result.NotFound();
        }

        return brand.ToBrandDto();
    }
}
