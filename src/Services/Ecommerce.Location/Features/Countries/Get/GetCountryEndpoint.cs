using Ecommerce.Location.Domain.CountryAggregate;

namespace Ecommerce.Location.Features.Countries.Get;

internal sealed class GetCountryEndpoint
    : IEndpoint<Results<Ok<CountryDto>, NotFound>, GetCountryQuery, ISender>
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet(
                "/countries/{id:long}",
                async (ISender sender, long id) => await HandleAsync(new(id), sender)
            )
            .ProducesOk<CountryDto>()
            .ProducesNotFound()
            .WithOpenApi()
            .WithTags(nameof(Country))
            .MapToApiVersion(new(1, 0));
    }

    public async Task<Results<Ok<CountryDto>, NotFound>> HandleAsync(
        GetCountryQuery request,
        ISender sender,
        CancellationToken cancellationToken = default
    )
    {
        var result = await sender.Send(request, cancellationToken);

        return result.Status == ResultStatus.NotFound
            ? TypedResults.NotFound()
            : TypedResults.Ok(result.Value);
    }
}
