using Ecommerce.Catalog.Domain.ProductAggregate;

namespace Ecommerce.Catalog.Features.Products.Update;

internal sealed class UpdateProductEndpoint : IEndpoint<Ok, UpdateProductCommand, ISender>
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPut(
                "/products",
                async (UpdateProductCommand request, ISender sender) =>
                    await HandleAsync(request, sender)
            )
            .ProducesOk()
            .ProducesValidationProblem()
            .ProducesNotFound()
            .WithOpenApi()
            .WithTags(nameof(Product))
            .MapToApiVersion(new(1, 0))
            .RequireAuthorization(Constant.Auth.Policies.Admin);
    }

    public async Task<Ok> HandleAsync(
        UpdateProductCommand request,
        ISender sender,
        CancellationToken cancellationToken = default
    )
    {
        await sender.Send(request, cancellationToken);

        return TypedResults.Ok();
    }
}
