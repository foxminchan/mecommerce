namespace Ecommerce.Media.Features.Create;

internal sealed class CreateMediaEndpoint : IEndpoint<Created<Guid>, CreateMediaCommand, ISender>
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPost(
                "/medias",
                async ([FromForm] CreateMediaCommand request, ISender sender) =>
                    await HandleAsync(request, sender)
            )
            .AddEndpointFilter<FileValidationFilter>()
            .ProducesCreated<Guid>()
            .ProducesValidationProblem()
            .DisableAntiforgery()
            .WithOpenApi()
            .WithTags(nameof(Media))
            .WithFormOptions(bufferBody: true)
            .MapToApiVersion(new(1, 0));
    }

    public async Task<Created<Guid>> HandleAsync(
        CreateMediaCommand request,
        ISender sender,
        CancellationToken cancellationToken = default
    )
    {
        var result = await sender.Send(request, cancellationToken);

        return TypedResults.Created($"/api/v1/{result.Value}", result.Value);
    }
}
