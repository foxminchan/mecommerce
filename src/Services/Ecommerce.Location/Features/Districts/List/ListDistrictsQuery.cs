using Ecommerce.Location.Domain.DistrictAggregate;
using Ecommerce.Location.Domain.DistrictAggregate.Specifications;

namespace Ecommerce.Location.Features.Districts.List;

internal sealed record ListDistrictsQuery(long? StateOrProvinceId, string? Name)
    : IQuery<Result<IEnumerable<DistrictDto>>>;

internal sealed class ListDistrictsHandler(IReadRepository<District> repository)
    : IQueryHandler<ListDistrictsQuery, Result<IEnumerable<DistrictDto>>>
{
    public async Task<Result<IEnumerable<DistrictDto>>> Handle(
        ListDistrictsQuery request,
        CancellationToken cancellationToken
    )
    {
        var districts = await repository.ListAsync(
            new DistrictFilterSpec(request.StateOrProvinceId, request.Name),
            cancellationToken
        );

        return Result.Success(districts.Select(EntityToDto.ToDistrictDto));
    }
}
