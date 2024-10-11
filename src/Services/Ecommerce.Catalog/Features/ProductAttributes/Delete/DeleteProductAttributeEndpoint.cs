using Ecommerce.Catalog.Domain.ProductAttributeAggregate;

namespace Ecommerce.Catalog.Features.ProductAttributes.Delete;

internal sealed class DeleteProductAttributeEndpoint
    : IEndpoint<NoContent, DeleteProductAttributeCommand, ISender>
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapDelete(
                "/product-attributes/{id:long}",
                async (long id, ISender sender) => await HandleAsync(new(id), sender)
            )
            .ProducesNoContent()
            .ProducesNotFound()
            .WithOpenApi()
            .WithTags(nameof(ProductAttribute).Humanize(LetterCasing.Title))
            .MapToApiVersion(new(1, 0))
            .RequireAuthorization(Constant.Auth.Policies.Admin);
    }

    public async Task<NoContent> HandleAsync(
        DeleteProductAttributeCommand request,
        ISender sender,
        CancellationToken cancellationToken = default
    )
    {
        await sender.Send(request, cancellationToken);

        return TypedResults.NoContent();
    }
}
