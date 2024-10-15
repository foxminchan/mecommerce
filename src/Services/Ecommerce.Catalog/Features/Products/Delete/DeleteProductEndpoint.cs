using Ecommerce.Catalog.Domain.ProductAggregate;

namespace Ecommerce.Catalog.Features.Products.Delete;

internal sealed class DeleteProductEndpoint : IEndpoint<NoContent, DeleteProductCommand, ISender>
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapDelete(
                "/products/{id:guid}",
                async (Guid id, ISender sender) => await HandleAsync(new(id), sender)
            )
            .ProducesNoContent()
            .ProducesNotFound()
            .WithOpenApi()
            .WithTags(nameof(Product))
            .MapToApiVersion(new(1, 0))
            .RequireAuthorization(Authorization.Policies.Admin);
    }

    public async Task<NoContent> HandleAsync(
        DeleteProductCommand request,
        ISender sender,
        CancellationToken cancellationToken = default
    )
    {
        await sender.Send(request, cancellationToken);

        return TypedResults.NoContent();
    }
}
