using Ecommerce.Location.Domain.WardOrCommuneAggregate;
using Auth = Ecommerce.Constant.Auth;

namespace Ecommerce.Location.Features.WardOrCommunes.Create;

internal sealed class CreateWardOrCommuneEndpoint
    : IEndpoint<Created<long>, CreateWardOrCommuneCommand, ISender>
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPost(
                "/ward-or-communes",
                async (CreateWardOrCommuneCommand request, ISender sender) =>
                    await HandleAsync(request, sender)
            )
            .ProducesCreated<long>()
            .ProducesValidationProblem()
            .WithOpenApi()
            .WithTags(nameof(WardOrCommune).Humanize(LetterCasing.Title))
            .MapToApiVersion(new(1, 0))
            .RequireAuthorization(Auth.Policies.Admin);
    }

    public async Task<Created<long>> HandleAsync(
        CreateWardOrCommuneCommand request,
        ISender sender,
        CancellationToken cancellationToken = default
    )
    {
        var result = await sender.Send(request, cancellationToken);

        return TypedResults.Created($"/api/v1/{result.Value}", result.Value);
    }
}
