using Ecommerce.Location.Domain.WardOrCommuneAggregate;
using Ecommerce.Location.Domain.WardOrCommuneAggregate.Specifications;

namespace Ecommerce.Location.Features.WardOrCommunes.ListPagination;

internal sealed class ListWardOrCommunesPaginationEndpoint
    : IEndpoint<Ok<PagedItems<WardOrCommuneDto>>, ListWardOrCommunesPaginationQuery, ISender>
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet(
                "/ward-or-communes/by",
                async ([AsParameters] ListWardOrCommunesRequest request, ISender sender) =>
                    await HandleAsync(new(request), sender)
            )
            .ProducesOk<PagedItems<WardOrCommuneDto>>()
            .ProducesValidationProblem()
            .WithOpenApi()
            .WithTags(nameof(WardOrCommune).Humanize(LetterCasing.Title))
            .MapToApiVersion(new(1, 0));
    }

    public async Task<Ok<PagedItems<WardOrCommuneDto>>> HandleAsync(
        ListWardOrCommunesPaginationQuery request,
        ISender sender,
        CancellationToken cancellationToken = default
    )
    {
        var result = await sender.Send(request, cancellationToken);

        var response = new PagedItems<WardOrCommuneDto>(result.PagedInfo, result.Value.ToList());

        return TypedResults.Ok(response);
    }
}
