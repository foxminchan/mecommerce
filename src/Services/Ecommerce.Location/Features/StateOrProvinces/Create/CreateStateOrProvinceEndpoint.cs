using Ecommerce.Location.Domain.StateOrProvinceAggregate;
using Auth = Ecommerce.Constant.Auth;

namespace Ecommerce.Location.Features.StateOrProvinces.Create;

internal sealed class CreateStateOrProvinceEndpoint
    : IEndpoint<Created<long>, CreateStateOrProvinceCommand, ISender>
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPost(
                "/state-or-provinces",
                async (CreateStateOrProvinceCommand request, ISender sender) =>
                    await HandleAsync(request, sender)
            )
            .ProducesCreated<long>()
            .ProducesValidationProblem()
            .WithOpenApi()
            .WithTags(nameof(StateOrProvince).Humanize(LetterCasing.Title))
            .MapToApiVersion(new(1, 0))
            .RequireAuthorization(Auth.Policies.Admin);
    }

    public async Task<Created<long>> HandleAsync(
        CreateStateOrProvinceCommand request,
        ISender sender,
        CancellationToken cancellationToken = default
    )
    {
        var result = await sender.Send(request, cancellationToken);

        return TypedResults.Created($"/api/v1/state-or-provinces/{result.Value}", result.Value);
    }
}
