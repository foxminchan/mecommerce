using Ecommerce.Location.Domain.StateOrProvinceAggregate;

namespace Ecommerce.Location.Features.StateOrProvinces.Get;

internal sealed class GetStateOrProvinceEndpoint
    : IEndpoint<Results<Ok<StateOrProvinceDto>, NotFound>, GetStateOrProvinceQuery, ISender>
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet(
                "/state-or-provinces/{id:long}",
                async (long id, ISender sender) => await HandleAsync(new(id), sender)
            )
            .ProducesOk<StateOrProvinceDto>()
            .ProducesNotFound()
            .WithOpenApi()
            .WithTags(nameof(StateOrProvince).Humanize(LetterCasing.Title))
            .MapToApiVersion(new(1, 0));
    }

    public async Task<Results<Ok<StateOrProvinceDto>, NotFound>> HandleAsync(
        GetStateOrProvinceQuery request,
        ISender sender,
        CancellationToken cancellationToken = default
    )
    {
        var result = await sender.Send(request, cancellationToken);

        return result.Status == ResultStatus.NotFound
            ? TypedResults.NotFound()
            : TypedResults.Ok(result.Value);
    }
}
