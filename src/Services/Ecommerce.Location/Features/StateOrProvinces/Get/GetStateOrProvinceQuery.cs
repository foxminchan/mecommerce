using Ecommerce.Location.Domain.StateOrProvinceAggregate;

namespace Ecommerce.Location.Features.StateOrProvinces.Get;

internal sealed record GetStateOrProvinceQuery(long Id) : IQuery<Result<StateOrProvinceDto>>;

internal sealed class GetStateOrProvinceHandler(IReadRepository<StateOrProvince> repository)
    : IQueryHandler<GetStateOrProvinceQuery, Result<StateOrProvinceDto>>
{
    public async Task<Result<StateOrProvinceDto>> Handle(
        GetStateOrProvinceQuery request,
        CancellationToken cancellationToken
    )
    {
        var stateOrProvince = await repository.GetByIdAsync(request.Id, cancellationToken);

        if (stateOrProvince is null)
        {
            return Result.NotFound();
        }

        return stateOrProvince.ToStateOrProvinceDto();
    }
}
