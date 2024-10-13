using Ecommerce.Location.Domain.CountryAggregate;

namespace Ecommerce.Location.Features.Countries.Create;

internal sealed class CreateCountryEndpoint
    : IEndpoint<Created<long>, CreateCountryCommand, ISender>
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPost(
                "/countries",
                async (CreateCountryCommand request, ISender sender) =>
                    await HandleAsync(request, sender)
            )
            .ProducesCreated<long>()
            .ProducesValidationProblem()
            .WithOpenApi()
            .WithTags(nameof(Country))
            .MapToApiVersion(new(1, 0));
    }

    public async Task<Created<long>> HandleAsync(
        CreateCountryCommand request,
        ISender sender,
        CancellationToken cancellationToken = default
    )
    {
        var result = await sender.Send(request, cancellationToken);

        return TypedResults.Created($"/api/v1/{result.Value}", result.Value);
    }
}
