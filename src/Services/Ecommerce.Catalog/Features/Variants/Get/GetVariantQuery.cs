using Ecommerce.Catalog.Domain.VariantAggregate;
using Ecommerce.Catalog.Domain.VariantAggregate.Specifications;

namespace Ecommerce.Catalog.Features.Variants.Get;

internal sealed record GetVariantQuery(long Id) : IQuery<Result<VariantDto>>;

internal sealed class GetVariantHandler(IReadRepository<Variant> repository)
    : IQueryHandler<GetVariantQuery, Result<VariantDto>>
{
    public async Task<Result<VariantDto>> Handle(
        GetVariantQuery request,
        CancellationToken cancellationToken
    )
    {
        var variant = await repository.FirstOrDefaultAsync(
            new VariantFilterSpec(request.Id),
            cancellationToken
        );

        if (variant is null)
        {
            return Result.NotFound();
        }

        return variant.ToVariantDto();
    }
}
