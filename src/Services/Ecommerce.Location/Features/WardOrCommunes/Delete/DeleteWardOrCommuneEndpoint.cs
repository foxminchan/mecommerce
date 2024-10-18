using Ecommerce.Location.Domain.WardOrCommuneAggregate;
using Auth = Ecommerce.Constant.Auth;

namespace Ecommerce.Location.Features.WardOrCommunes.Delete;

internal sealed class DeleteWardOrCommuneEndpoint
    : IEndpoint<Results<NoContent, NotFound>, DeleteWardOrCommuneCommand, ISender>
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapDelete(
                "/ward-or-communes/{id:long}",
                async (long id, ISender sender) => await HandleAsync(new(id), sender)
            )
            .ProducesNoContent()
            .ProducesNotFound()
            .ProducesValidationProblem()
            .WithOpenApi()
            .WithTags(nameof(WardOrCommune).Humanize(LetterCasing.Title))
            .MapToApiVersion(new(1, 0))
            .RequireAuthorization(Auth.Policies.Admin);
    }

    public async Task<Results<NoContent, NotFound>> HandleAsync(
        DeleteWardOrCommuneCommand request,
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
