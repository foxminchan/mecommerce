using Ecommerce.Location.Domain.StateOrProvinceAggregate;

namespace Ecommerce.Location.Features.StateOrProvinces.Update;

internal sealed class UpdateStateOrProvinceEndpoint
    : IEndpoint<Results<Ok, NotFound>, UpdateStateOrProvinceCommand, ISender>
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPut(
                "/state-or-provinces",
                async (UpdateStateOrProvinceCommand request, ISender sender) =>
                    await HandleAsync(request, sender)
            )
            .ProducesOk()
            .ProducesNotFound()
            .ProducesValidationProblem()
            .WithOpenApi()
            .WithTags(nameof(StateOrProvince).Humanize(LetterCasing.Title))
            .MapToApiVersion(new(1, 0))
            .RequireAuthorization(Authorization.Policies.Admin);
    }

    public async Task<Results<Ok, NotFound>> HandleAsync(
        UpdateStateOrProvinceCommand request,
        ISender sender,
        CancellationToken cancellationToken = default
    )
    {
        var result = await sender.Send(request, cancellationToken);

        return result.Status == ResultStatus.NotFound ? TypedResults.NotFound() : TypedResults.Ok();
    }
}
