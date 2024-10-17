using Ecommerce.Location.Domain.WardOrCommuneAggregate;
using Ecommerce.Location.Domain.WardOrCommuneAggregate.Specifications;

namespace Ecommerce.Location.Features.WardOrCommunes.List;

internal sealed record ListWardOrCommunesQuery(long? DistrictId, string? Name)
    : IQuery<Result<IEnumerable<WardOrCommuneDto>>>;

internal sealed class ListWardOrCommunesHandler(IReadRepository<WardOrCommune> repository)
    : IQueryHandler<ListWardOrCommunesQuery, Result<IEnumerable<WardOrCommuneDto>>>
{
    public async Task<Result<IEnumerable<WardOrCommuneDto>>> Handle(
        ListWardOrCommunesQuery request,
        CancellationToken cancellationToken
    )
    {
        var spec = new WardOrCommuneFilterSpec(request.DistrictId, request.Name);

        var wardOrCommunes = await repository.ListAsync(spec, cancellationToken);

        return Result.Success(wardOrCommunes.ToWardOrCommuneDtos());
    }
}
