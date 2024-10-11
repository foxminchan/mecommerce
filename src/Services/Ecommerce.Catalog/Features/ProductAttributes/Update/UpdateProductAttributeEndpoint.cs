using Ecommerce.Catalog.Domain.ProductAttributeAggregate;

namespace Ecommerce.Catalog.Features.ProductAttributes.Update;

internal sealed class UpdateProductAttributeEndpoint
    : IEndpoint<Ok, UpdateProductAttributeCommand, ISender>
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPut(
                "/product-attributes",
                async (UpdateProductAttributeCommand request, ISender sender) =>
                    await HandleAsync(request, sender)
            )
            .ProducesOk()
            .ProducesValidationProblem()
            .WithOpenApi()
            .WithTags(nameof(ProductAttribute).Humanize(LetterCasing.Title))
            .MapToApiVersion(new(1, 0))
            .RequireAuthorization(Constant.Auth.Policies.Admin);
    }

    public async Task<Ok> HandleAsync(
        UpdateProductAttributeCommand request,
        ISender sender,
        CancellationToken cancellationToken = default
    )
    {
        await sender.Send(request, cancellationToken);

        return TypedResults.Ok();
    }
}
