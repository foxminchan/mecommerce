using Ecommerce.Location.Domain.WardOrCommuneAggregate;

namespace Ecommerce.Location.Features.WardOrCommunes.Get;

internal sealed class GetWardOrCommuneEndpoint
    : IEndpoint<Results<Ok<WardOrCommuneDto>, NotFound>, GetWardOrCommuneQuery, ISender>
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet(
                "/ward-or-communes/{id:long}",
                async (long id, ISender sender) => await HandleAsync(new(id), sender)
            )
            .ProducesOk<WardOrCommuneDto>()
            .ProducesNotFound()
            .WithOpenApi()
            .WithTags(nameof(WardOrCommune).Humanize(LetterCasing.Title))
            .MapToApiVersion(new(1, 0));
    }

    public async Task<Results<Ok<WardOrCommuneDto>, NotFound>> HandleAsync(
        GetWardOrCommuneQuery request,
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
