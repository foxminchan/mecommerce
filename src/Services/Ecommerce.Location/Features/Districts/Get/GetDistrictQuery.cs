using Ecommerce.Location.Domain.DistrictAggregate;

namespace Ecommerce.Location.Features.Districts.Get;

internal sealed record GetDistrictQuery(long Id) : IQuery<Result<DistrictDto>>;

internal sealed class GetDistrictHandler(IReadRepository<District> repository)
    : IQueryHandler<GetDistrictQuery, Result<DistrictDto>>
{
    public async Task<Result<DistrictDto>> Handle(
        GetDistrictQuery request,
        CancellationToken cancellationToken
    )
    {
        var district = await repository.GetByIdAsync(request.Id, cancellationToken);

        if (district is null)
        {
            return Result.NotFound();
        }

        return district.ToDistrictDto();
    }
}
