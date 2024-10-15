using Ecommerce.Location.Domain.StateOrProvinceAggregate;
using Ecommerce.Location.Domain.StateOrProvinceAggregate.Specifications;

namespace Ecommerce.Location.Features.StateOrProvinces.List;

internal sealed record ListStateOrProvincesQuery(long? CountryId, string? Name)
    : IQuery<Result<IEnumerable<StateOrProvinceDto>>>;

internal sealed class ListStateOrProvincesHandler(IReadRepository<StateOrProvince> repository)
    : IQueryHandler<ListStateOrProvincesQuery, Result<IEnumerable<StateOrProvinceDto>>>
{
    public async Task<Result<IEnumerable<StateOrProvinceDto>>> Handle(
        ListStateOrProvincesQuery query,
        CancellationToken cancellationToken
    )
    {
        var spec = new StateOrProvinceFilterSpec(query.CountryId, query.Name);

        var stateOrProvinces = await repository.ListAsync(spec, cancellationToken);

        return Result.Success(stateOrProvinces.ToStateOrProvinceDtos());
    }
}
