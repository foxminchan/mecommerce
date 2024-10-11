using Ecommerce.Catalog.Domain.BrandAggregate;

namespace Ecommerce.Catalog.Features.Brands.Update;

internal sealed class UpdateBrandEndpoint
    : IEndpoint<Results<Ok, NotFound>, UpdateBrandCommand, ISender>
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPut(
                "/brands",
                async (ISender sender, UpdateBrandCommand request) =>
                    await HandleAsync(request, sender)
            )
            .ProducesOk()
            .ProducesNotFound()
            .ProducesValidationProblem()
            .WithOpenApi()
            .WithTags(nameof(Brand))
            .MapToApiVersion(new(1, 0))
            .RequireAuthorization(Constant.Auth.Policies.Admin);
    }

    public async Task<Results<Ok, NotFound>> HandleAsync(
        UpdateBrandCommand request,
        ISender sender,
        CancellationToken cancellationToken = default
    )
    {
        var result = await sender.Send(request, cancellationToken);

        return result.Status == ResultStatus.NotFound ? TypedResults.NotFound() : TypedResults.Ok();
    }
}
