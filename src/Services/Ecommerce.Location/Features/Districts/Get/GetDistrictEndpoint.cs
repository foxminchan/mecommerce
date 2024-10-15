using Ecommerce.Location.Domain.DistrictAggregate;

namespace Ecommerce.Location.Features.Districts.Get;

internal sealed class GetDistrictEndpoint
    : IEndpoint<Results<Ok<DistrictDto>, NotFound>, GetDistrictQuery, ISender>
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet(
                "/districts/{id:long}",
                async (long id, ISender sender) => await HandleAsync(new(id), sender)
            )
            .ProducesOk<DistrictDto>()
            .ProducesNotFound()
            .WithOpenApi()
            .WithTags(nameof(District))
            .MapToApiVersion(new(1, 0));
    }

    public async Task<Results<Ok<DistrictDto>, NotFound>> HandleAsync(
        GetDistrictQuery request,
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
