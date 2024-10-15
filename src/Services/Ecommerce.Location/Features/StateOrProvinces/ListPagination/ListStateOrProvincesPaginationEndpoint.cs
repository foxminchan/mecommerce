using Ecommerce.Location.Domain.StateOrProvinceAggregate;
using Ecommerce.Location.Domain.StateOrProvinceAggregate.Specifications;

namespace Ecommerce.Location.Features.StateOrProvinces.ListPagination;

internal sealed class ListStateOrProvincesPaginationEndpoint
    : IEndpoint<Ok<PagedItems<StateOrProvinceDto>>, ListStateOrProvincesPaginationQuery, ISender>
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet(
                "/state-or-provinces/by",
                async ([AsParameters] ListStateOrProvincesRequest request, ISender sender) =>
                    await HandleAsync(new(request), sender)
            )
            .ProducesOk<PagedItems<StateOrProvinceDto>>()
            .WithOpenApi()
            .WithTags(nameof(StateOrProvince).Humanize(LetterCasing.Title))
            .MapToApiVersion(new(1, 0));
    }

    public async Task<Ok<PagedItems<StateOrProvinceDto>>> HandleAsync(
        ListStateOrProvincesPaginationQuery request,
        ISender sender,
        CancellationToken cancellationToken = default
    )
    {
        var result = await sender.Send(request, cancellationToken);

        var response = new PagedItems<StateOrProvinceDto>(result.PagedInfo, result.Value.ToList());

        return TypedResults.Ok(response);
    }
}
