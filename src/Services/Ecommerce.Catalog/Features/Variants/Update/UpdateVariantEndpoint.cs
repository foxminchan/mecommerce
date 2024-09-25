using Ecommerce.Catalog.Domain.VariantAggregate;

namespace Ecommerce.Catalog.Features.Variants.Update;

internal sealed class UpdateVariantEndpoint
    : IEndpoint<Results<Ok, NotFound>, UpdateVariantCommand, ISender>
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPut(
                "/variants",
                async (UpdateVariantCommand request, ISender sender) =>
                    await HandleAsync(request, sender)
            )
            .ProducesOk()
            .ProducesValidationProblem()
            .ProducesNotFound()
            .WithOpenApi()
            .WithTags(nameof(Variant))
            .MapToApiVersion(new(1, 0));
    }

    public async Task<Results<Ok, NotFound>> HandleAsync(
        UpdateVariantCommand request,
        ISender sender,
        CancellationToken cancellationToken = default
    )
    {
        var result = await sender.Send(request, cancellationToken);

        return result.Status == ResultStatus.NotFound ? TypedResults.NotFound() : TypedResults.Ok();
    }
}
