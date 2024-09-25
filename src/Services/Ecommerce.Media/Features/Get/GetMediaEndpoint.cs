namespace Ecommerce.Media.Features.Get;

internal sealed class GetMediaEndpoint
    : IEndpoint<Results<Ok<ImageDto>, NotFound>, GetMediaQuery, ISender>
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet(
                "/medias/{id:guid}",
                async (Guid id, ISender sender) => await HandleAsync(new(id), sender)
            )
            .ProducesOk<ImageDto>()
            .ProducesNotFound()
            .WithOpenApi()
            .WithTags(nameof(Media))
            .MapToApiVersion(new(1, 0));
    }

    public async Task<Results<Ok<ImageDto>, NotFound>> HandleAsync(
        GetMediaQuery request,
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
