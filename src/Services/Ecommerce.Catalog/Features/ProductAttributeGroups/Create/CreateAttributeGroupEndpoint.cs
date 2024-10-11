using Ecommerce.Catalog.Domain.ProductAttributeGroupAggregate;

namespace Ecommerce.Catalog.Features.ProductAttributeGroups.Create;

internal sealed class CreateAttributeGroupEndpoint
    : IEndpoint<Created<long>, CreateAttributeGroupCommand, ISender>
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPost(
                "/product-attribute-groups",
                async (CreateAttributeGroupCommand request, ISender sender) =>
                    await HandleAsync(request, sender)
            )
            .ProducesCreated<long>()
            .ProducesValidationProblem()
            .ProducesConflictProblem()
            .WithOpenApi()
            .WithTags(nameof(ProductAttributeGroup).Humanize(LetterCasing.Title))
            .MapToApiVersion(new(1, 0))
            .RequireAuthorization(Constant.Auth.Policies.Admin);
    }

    public async Task<Created<long>> HandleAsync(
        CreateAttributeGroupCommand request,
        ISender sender,
        CancellationToken cancellationToken = default
    )
    {
        var result = await sender.Send(request, cancellationToken);

        return TypedResults.Created(
            $"/api/v1/product-attribute-groups/{result.Value}",
            result.Value
        );
    }
}
