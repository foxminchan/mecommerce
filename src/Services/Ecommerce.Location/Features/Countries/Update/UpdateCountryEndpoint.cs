using Ecommerce.Location.Domain.CountryAggregate;
using Auth = Ecommerce.Constant.Auth;

namespace Ecommerce.Location.Features.Countries.Update;

internal sealed class UpdateCountryEndpoint
    : IEndpoint<Results<Ok, NotFound>, UpdateCountryCommand, ISender>
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPut(
                "/countries",
                async (UpdateCountryCommand request, ISender sender) =>
                    await HandleAsync(request, sender)
            )
            .ProducesOk()
            .ProducesNotFound()
            .ProducesValidationProblem()
            .WithOpenApi()
            .WithTags(nameof(Country))
            .MapToApiVersion(new(1, 0))
            .RequireAuthorization(Auth.Policies.Admin);
    }

    public async Task<Results<Ok, NotFound>> HandleAsync(
        UpdateCountryCommand request,
        ISender sender,
        CancellationToken cancellationToken = default
    )
    {
        var result = await sender.Send(request, cancellationToken);

        return result.Status == ResultStatus.NotFound ? TypedResults.NotFound() : TypedResults.Ok();
    }
}
