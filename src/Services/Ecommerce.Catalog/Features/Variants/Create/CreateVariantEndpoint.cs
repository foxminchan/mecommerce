using Ecommerce.Catalog.Domain.VariantAggregate;

namespace Ecommerce.Catalog.Features.Variants.Create;

internal sealed class CreateVariantEndpoint
    : IEndpoint<Created<long>, CreateVariantCommand, ISender>
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPost(
                "/variants",
                async (CreateVariantCommand request, ISender sender) =>
                    await HandleAsync(request, sender)
            )
            .ProducesCreated<long>()
            .ProducesValidationProblem()
            .WithOpenApi()
            .WithTags(nameof(Variant))
            .MapToApiVersion(new(1, 0))
            .RequireAuthorization(Constant.Auth.Policies.Admin);
    }

    public async Task<Created<long>> HandleAsync(
        CreateVariantCommand request,
        ISender sender,
        CancellationToken cancellationToken = default
    )
    {
        var result = await sender.Send(request, cancellationToken);

        return TypedResults.Created($"/api/v1/variants/{result.Value}", result.Value);
    }
}
