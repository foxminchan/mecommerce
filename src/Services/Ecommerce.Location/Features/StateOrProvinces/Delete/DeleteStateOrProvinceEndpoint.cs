using Ecommerce.Location.Domain.StateOrProvinceAggregate;

namespace Ecommerce.Location.Features.StateOrProvinces.Delete;

internal sealed class DeleteStateOrProvinceEndpoint
    : IEndpoint<Results<NoContent, NotFound>, DeleteStateOrProvinceCommand, ISender>
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapDelete(
                "/state-or-provinces/{id:long}",
                async (long id, ISender sender) => await HandleAsync(new(id), sender)
            )
            .ProducesNoContent()
            .ProducesNotFound()
            .ProducesValidationProblem()
            .WithOpenApi()
            .WithTags(nameof(StateOrProvince).Humanize(LetterCasing.Title))
            .MapToApiVersion(new(1, 0))
            .RequireAuthorization(Authorization.Policies.Admin);
    }

    public async Task<Results<NoContent, NotFound>> HandleAsync(
        DeleteStateOrProvinceCommand request,
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
