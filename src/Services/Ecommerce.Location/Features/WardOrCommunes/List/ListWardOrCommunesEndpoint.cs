using Ecommerce.Location.Domain.WardOrCommuneAggregate;

namespace Ecommerce.Location.Features.WardOrCommunes.List;

internal sealed class ListWardOrCommunesEndpoint
    : IEndpoint<Ok<List<WardOrCommuneDto>>, ListWardOrCommunesQuery, ISender>
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet(
                "/ward-or-communes",
                async ([AsParameters] ListWardOrCommunesQuery query, ISender sender) =>
                    await HandleAsync(query, sender)
            )
            .ProducesOk<List<WardOrCommuneDto>>()
            .WithOpenApi()
            .WithTags(nameof(WardOrCommune).Humanize(LetterCasing.Title))
            .MapToApiVersion(new(1, 0));
    }

    public async Task<Ok<List<WardOrCommuneDto>>> HandleAsync(
        ListWardOrCommunesQuery request,
        ISender sender,
        CancellationToken cancellationToken = default
    )
    {
        var result = await sender.Send(request, cancellationToken);

        return TypedResults.Ok(result.Value.ToList());
    }
}
