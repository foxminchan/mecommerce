using Ecommerce.Location.Domain.StateOrProvinceAggregate;

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
            .RequireAuthorization(Authorization.Policies.Admin);
    }

    public async Task<Created<long>> HandleAsync(
        CreateStateOrProvinceCommand request,
        ISender sender,
        CancellationToken cancellationToken = default
    )
    {
        var result = await sender.Send(request, cancellationToken);

        return TypedResults.Created(
            new UrlBuilder()
                .WithVersion()
                .WithResource("state-or-provinces")
                .WithId(result.Value)
                .Build(),
            result.Value
        );
    }
}
