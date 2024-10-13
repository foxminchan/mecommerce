using Ecommerce.Location.Domain.CountryAggregate;

namespace Ecommerce.Location.Features.Countries.ListPagination;

internal class ListCountriesPaginationEndpoint
    : IEndpoint<Ok<PagedItems<CountryDto>>, ListCountriesPaginationQuery, ISender>
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet(
                "/countries/by",
                async ([AsParameters] PaginationRequest filter, ISender sender) =>
                    await HandleAsync(new(filter), sender)
            )
            .ProducesOk<PagedItems<CountryDto>>()
            .ProducesValidationProblem()
            .WithOpenApi()
            .WithTags(nameof(Country))
            .MapToApiVersion(new(1, 0));
    }

    public async Task<Ok<PagedItems<CountryDto>>> HandleAsync(
        ListCountriesPaginationQuery request,
        ISender sender,
        CancellationToken cancellationToken = default
    )
    {
        var result = await sender.Send(request, cancellationToken);

        var response = new PagedItems<CountryDto>(result.PagedInfo, result.Value.ToList());

        return TypedResults.Ok(response);
    }
}
