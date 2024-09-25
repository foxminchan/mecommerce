using Ecommerce.Catalog.Domain.VariantAggregate;
using Ecommerce.Catalog.Domain.VariantAggregate.Specifications;

namespace Ecommerce.Catalog.Features.Variants.List;

internal sealed record ListVariantsQuery : IQuery<Result<IEnumerable<VariantDto>>>;

internal sealed class ListVariantsHandler(IReadRepository<Variant> repository)
    : IQueryHandler<ListVariantsQuery, Result<IEnumerable<VariantDto>>>
{
    public async Task<Result<IEnumerable<VariantDto>>> Handle(
        ListVariantsQuery query,
        CancellationToken cancellationToken
    )
    {
        var variants = await repository.ListAsync(new VariantFilterSpec(), cancellationToken);

        return Result.Success(variants.ToVariantDtos());
    }
}
