using Ecommerce.Catalog.Domain.CategoryAggregate;

namespace Ecommerce.Catalog.Features.Categories.Create;

internal sealed class CreateCategoryEndpoint
    : IEndpoint<Created<long>, CreateCategoryCommand, ISender>
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPost(
                "/categories",
                async (CreateCategoryCommand request, ISender sender) =>
                    await HandleAsync(request, sender)
            )
            .ProducesCreated<long>()
            .ProducesValidationProblem()
            .ProducesConflictProblem()
            .WithOpenApi()
            .WithTags(nameof(Category))
            .MapToApiVersion(new(1, 0))
            .RequireAuthorization(Constant.Auth.Policies.Admin);
    }

    public async Task<Created<long>> HandleAsync(
        CreateCategoryCommand request,
        ISender sender,
        CancellationToken cancellationToken = default
    )
    {
        var result = await sender.Send(request, cancellationToken);

        return TypedResults.Created($"/api/v1/categories/{result.Value}", result.Value);
    }
}
