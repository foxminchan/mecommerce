using Ecommerce.Location.Domain.DistrictAggregate;
using Ecommerce.Location.Domain.DistrictAggregate.Specifications;

namespace Ecommerce.Location.Features.Districts.ListPagination;

internal sealed class ListDistrictsPaginationEndpoint
    : IEndpoint<Ok<PagedItems<DistrictDto>>, ListDistrictsPaginationQuery, ISender>
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet(
                "/districts/by",
                async ([AsParameters] ListDistrictsRequest request, ISender sender) =>
                    await HandleAsync(new(request), sender)
            )
            .ProducesOk<List<DistrictDto>>()
            .ProducesValidationProblem()
            .WithOpenApi()
            .WithTags(nameof(District))
            .MapToApiVersion(new(1, 0));
    }

    public async Task<Ok<PagedItems<DistrictDto>>> HandleAsync(
        ListDistrictsPaginationQuery request,
        ISender sender,
        CancellationToken cancellationToken = default
    )
    {
        var result = await sender.Send(request, cancellationToken);

        var response = new PagedItems<DistrictDto>(result.PagedInfo, result.Value.ToList());

        return TypedResults.Ok(response);
    }
}
