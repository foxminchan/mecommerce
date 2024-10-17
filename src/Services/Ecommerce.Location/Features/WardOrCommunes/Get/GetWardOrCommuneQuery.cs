using Ecommerce.Location.Domain.WardOrCommuneAggregate;

namespace Ecommerce.Location.Features.WardOrCommunes.Get;

internal sealed record GetWardOrCommuneQuery(long Id) : IQuery<Result<WardOrCommuneDto>>;

internal sealed class GetWardOrCommuneHandler(IReadRepository<WardOrCommune> repository)
    : IQueryHandler<GetWardOrCommuneQuery, Result<WardOrCommuneDto>>
{
    public async Task<Result<WardOrCommuneDto>> Handle(
        GetWardOrCommuneQuery request,
        CancellationToken cancellationToken
    )
    {
        var wardOrCommune = await repository.GetByIdAsync(request.Id, cancellationToken);

        if (wardOrCommune is null)
        {
            return Result.NotFound();
        }

        return wardOrCommune.ToWardOrCommuneDto();
    }
}
