namespace Ecommerce.Media.Features.GetFile;

internal sealed class GetFileEndpoint
    : IEndpoint<Results<FileStreamHttpResult, NotFound>, GetFileQuery, string?, ISender>
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet(
                "/medias/{id:guid}/file",
                async (Guid id, ISender sender, string? fileName) =>
                    await HandleAsync(new(id), fileName, sender)
            )
            .ProducesStream()
            .ProducesNotFound()
            .WithOpenApi()
            .WithTags(nameof(Media))
            .MapToApiVersion(new(1, 0));
    }

    public async Task<Results<FileStreamHttpResult, NotFound>> HandleAsync(
        GetFileQuery request,
        string? fileName,
        ISender sender,
        CancellationToken cancellationToken = default
    )
    {
        var result = await sender.Send(request, cancellationToken);

        var file = result.Value;

        return result.Status == ResultStatus.NotFound
            ? TypedResults.NotFound()
            : TypedResults.Stream(file.Stream, file.ContentType, fileName ?? file.FileName);
    }
}
