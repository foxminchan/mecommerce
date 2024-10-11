using Ecommerce.Catalog.Domain.ProductAttributeGroupAggregate;

namespace Ecommerce.Catalog.Features.ProductAttributeGroups.Update;

internal sealed class UpdateProductAttributeGroupEndpoint
    : IEndpoint<Results<Ok, NotFound>, UpdateProductAttributeGroupCommand, ISender>
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPut(
                "/product-attribute-groups",
                async (UpdateProductAttributeGroupCommand request, ISender sender) =>
                    await HandleAsync(request, sender)
            )
            .ProducesOk()
            .ProducesNotFound()
            .ProducesValidationProblem()
            .WithOpenApi()
            .WithTags(nameof(ProductAttributeGroup).Humanize(LetterCasing.Title))
            .MapToApiVersion(new(1, 0))
            .RequireAuthorization(Constant.Auth.Policies.Admin);
    }

    public async Task<Results<Ok, NotFound>> HandleAsync(
        UpdateProductAttributeGroupCommand request,
        ISender sender,
        CancellationToken cancellationToken = default
    )
    {
        var result = await sender.Send(request, cancellationToken);

        return result.Status == ResultStatus.NotFound ? TypedResults.NotFound() : TypedResults.Ok();
    }
}
