using Ecommerce.Tax.Domain.CategoryAggregate;

namespace Ecommerce.Tax.Features.Categories.Update;

internal sealed class UpdateCategoryEndpoint
    : IEndpoint<Results<Ok, NotFound>, UpdateCategoryCommand, ISender>
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPut(
                "/categories",
                async (UpdateCategoryCommand request, ISender sender) =>
                    await HandleAsync(request, sender)
            )
            .ProducesOk()
            .ProducesNotFound()
            .ProducesValidationProblem()
            .WithOpenApi()
            .WithTags(nameof(Category))
            .MapToApiVersion(new(1, 0))
            .RequireAuthorization(Authorization.Policies.Admin);
    }

    public async Task<Results<Ok, NotFound>> HandleAsync(
        UpdateCategoryCommand request,
        ISender sender,
        CancellationToken cancellationToken = default
    )
    {
        var result = await sender.Send(request, cancellationToken);

        return result.Status == ResultStatus.NotFound ? TypedResults.NotFound() : TypedResults.Ok();
    }
}
