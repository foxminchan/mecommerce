namespace Ecommerce.Media.Features.Delete;

internal sealed class DeleteMediaEndpoint
    : IEndpoint<Results<NoContent, NotFound>, DeleteMediaCommand, ISender>
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapDelete(
                "/medias/{id:guid}",
                async (Guid id, ISender sender) => await HandleAsync(new(id), sender)
            )
            .ProducesNoContent()
            .ProducesNotFound()
            .WithOpenApi()
            .WithTags(nameof(Media))
            .MapToApiVersion(new(1, 0));
    }

    public async Task<Results<NoContent, NotFound>> HandleAsync(
        DeleteMediaCommand request,
        ISender sender,
        CancellationToken cancellationToken = default
    )
    {
        var result = await sender.Send(request, cancellationToken);

        return result.Status == ResultStatus.NotFound
            ? TypedResults.NotFound()
            : TypedResults.NoContent();
    }
}
