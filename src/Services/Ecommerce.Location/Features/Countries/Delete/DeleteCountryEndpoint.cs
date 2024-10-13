using Ecommerce.Location.Domain.CountryAggregate;

namespace Ecommerce.Location.Features.Countries.Delete;

internal sealed class DeleteCountryEndpoint
    : IEndpoint<Results<NoContent, NotFound>, DeleteCountryCommand, ISender>
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapDelete(
                "/countries/{id:long}",
                async (ISender sender, long id) => await HandleAsync(new(id), sender)
            )
            .ProducesNoContent()
            .ProducesNotFound()
            .ProducesValidationProblem()
            .WithOpenApi()
            .WithTags(nameof(Country))
            .MapToApiVersion(new(1, 0));
    }

    public async Task<Results<NoContent, NotFound>> HandleAsync(
        DeleteCountryCommand request,
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
