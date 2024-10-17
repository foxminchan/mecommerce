using Ecommerce.Location.Domain.WardOrCommuneAggregate;

namespace Ecommerce.Location.Features.WardOrCommunes.Update;

internal sealed class UpdateWardOrCommuneEndpoint
    : IEndpoint<Results<Ok, NotFound>, UpdateWardOrCommuneCommand, ISender>
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPut(
                "/ward-or-communes",
                async (UpdateWardOrCommuneCommand request, ISender sender) =>
                    await HandleAsync(request, sender)
            )
            .ProducesOk()
            .ProducesNotFound()
            .ProducesValidationProblem()
            .WithOpenApi()
            .WithTags(nameof(WardOrCommune))
            .MapToApiVersion(new(1, 0));
    }

    public async Task<Results<Ok, NotFound>> HandleAsync(
        UpdateWardOrCommuneCommand request,
        ISender sender,
        CancellationToken cancellationToken = default
    )
    {
        var result = await sender.Send(request, cancellationToken);

        return result.Status == ResultStatus.NotFound ? TypedResults.NotFound() : TypedResults.Ok();
    }
}
