using Ecommerce.Catalog.Domain.ProductAggregate;

namespace Ecommerce.Catalog.Features.Products.Create;

internal sealed class CreateProductEndpoint
    : IEndpoint<Created<Guid>, CreateProductCommand, ISender>
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPost(
                "/products",
                async (CreateProductCommand request, ISender sender) =>
                    await HandleAsync(request, sender)
            )
            .ProducesCreated<Guid>()
            .ProducesValidationProblem()
            .WithOpenApi()
            .WithTags(nameof(Product))
            .MapToApiVersion(new(1, 0));
    }

    public async Task<Created<Guid>> HandleAsync(
        CreateProductCommand request,
        ISender sender,
        CancellationToken cancellationToken = default
    )
    {
        var result = await sender.Send(request, cancellationToken);

        return TypedResults.Created($"/api/v1/{result.Value}", result.Value);
    }
}
