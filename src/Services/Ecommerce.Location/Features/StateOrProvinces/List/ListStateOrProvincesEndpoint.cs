using Ecommerce.Location.Domain.StateOrProvinceAggregate;

namespace Ecommerce.Location.Features.StateOrProvinces.List;

internal sealed class ListStateOrProvincesEndpoint
    : IEndpoint<Ok<List<StateOrProvinceDto>>, ListStateOrProvincesQuery, ISender>
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet(
                "/state-or-provinces",
                async ([AsParameters] ListStateOrProvincesQuery request, ISender sender) =>
                    await HandleAsync(request, sender)
            )
            .ProducesOk<List<StateOrProvinceDto>>()
            .WithOpenApi()
            .WithTags(nameof(StateOrProvince).Humanize(LetterCasing.Title))
            .MapToApiVersion(new(1, 0));
    }

    public async Task<Ok<List<StateOrProvinceDto>>> HandleAsync(
        ListStateOrProvincesQuery request,
        ISender sender,
        CancellationToken cancellationToken = default
    )
    {
        var result = await sender.Send(request, cancellationToken);

        return TypedResults.Ok(result.Value.ToList());
    }
}
