using Ecommerce.Location.Domain.WardOrCommuneAggregate;
using Auth = Ecommerce.Constant.Auth;

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
            .WithTags(nameof(WardOrCommune).Humanize(LetterCasing.Title))
            .MapToApiVersion(new(1, 0))
            .RequireAuthorization(Auth.Policies.Admin);
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
