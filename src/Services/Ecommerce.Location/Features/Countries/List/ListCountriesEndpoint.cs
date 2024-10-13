using Ecommerce.Location.Domain.CountryAggregate;

namespace Ecommerce.Location.Features.Countries.List;

internal sealed class ListCountriesEndpoint
    : IEndpoint<Ok<List<CountryDto>>, ListCountriesQuery, ISender>
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet("/countries", async (ISender sender) => await HandleAsync(new(), sender))
            .ProducesOk<List<CountryDto>>()
            .WithOpenApi()
            .WithTags(nameof(Country))
            .MapToApiVersion(new(1, 0));
    }

    public async Task<Ok<List<CountryDto>>> HandleAsync(
        ListCountriesQuery request,
        ISender sender,
        CancellationToken cancellationToken = default
    )
    {
        var result = await sender.Send(request, cancellationToken);

        return TypedResults.Ok(result.Value.ToList());
    }
}
