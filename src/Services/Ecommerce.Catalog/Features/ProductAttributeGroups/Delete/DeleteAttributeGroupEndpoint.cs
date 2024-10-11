using Ecommerce.Catalog.Domain.ProductAttributeGroupAggregate;

namespace Ecommerce.Catalog.Features.ProductAttributeGroups.Delete;

internal sealed class DeleteAttributeGroupEndpoint
    : IEndpoint<Results<NoContent, NotFound>, DeleteAttributeGroupCommand, ISender>
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapDelete(
                "/product-attribute-groups/{id:long}",
                async (long id, ISender sender) => await HandleAsync(new(id), sender)
            )
            .ProducesNoContent()
            .ProducesNotFound()
            .WithOpenApi()
            .WithTags(nameof(ProductAttributeGroup).Humanize(LetterCasing.Title))
            .MapToApiVersion(new(1, 0))
            .RequireAuthorization(Constant.Auth.Policies.Admin);
    }

    public async Task<Results<NoContent, NotFound>> HandleAsync(
        DeleteAttributeGroupCommand request,
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
