using Ecommerce.Catalog.Domain.VariantAggregate;

namespace Ecommerce.Catalog.Features.Variants.Delete;

internal sealed class DeleteVariantEndpoint
    : IEndpoint<Results<NoContent, NotFound>, DeleteVariantCommand, ISender>
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapDelete(
                "/variants/{id:long}",
                async (long id, ISender sender) => await HandleAsync(new(id), sender)
            )
            .ProducesNoContent()
            .ProducesNotFound()
            .ProducesValidationProblem()
            .WithOpenApi()
            .WithTags(nameof(Variant))
            .MapToApiVersion(new(1, 0));
    }

    public async Task<Results<NoContent, NotFound>> HandleAsync(
        DeleteVariantCommand request,
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
