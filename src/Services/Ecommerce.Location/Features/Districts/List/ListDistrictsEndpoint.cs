using Ecommerce.Location.Domain.DistrictAggregate;

namespace Ecommerce.Location.Features.Districts.List;

internal sealed class ListDistrictsEndpoint
    : IEndpoint<Ok<List<DistrictDto>>, ListDistrictsQuery, ISender>
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet(
                "/districts",
                async ([AsParameters] ListDistrictsQuery request, ISender sender) =>
                    await HandleAsync(request, sender)
            )
            .ProducesOk<List<DistrictDto>>()
            .WithOpenApi()
            .WithTags(nameof(District))
            .MapToApiVersion(new(1, 0));
    }

    public async Task<Ok<List<DistrictDto>>> HandleAsync(
        ListDistrictsQuery request,
        ISender sender,
        CancellationToken cancellationToken = default
    )
    {
        var result = await sender.Send(request, cancellationToken);

        return TypedResults.Ok(result.Value.ToList());
    }
}
