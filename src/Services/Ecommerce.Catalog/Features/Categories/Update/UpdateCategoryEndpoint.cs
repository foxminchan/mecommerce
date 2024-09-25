using Ecommerce.Catalog.Domain.CategoryAggregate;

namespace Ecommerce.Catalog.Features.Categories.Update;

internal sealed class UpdateCategoryEndpoint
    : IEndpoint<Results<Ok, NotFound>, UpdateCategoryCommand, ISender>
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPut(
                "/categories",
                async (ISender sender, UpdateCategoryCommand command) =>
                    await HandleAsync(command, sender)
            )
            .ProducesOk()
            .ProducesNotFound()
            .ProducesValidationProblem()
            .WithOpenApi()
            .WithTags(nameof(Category))
            .MapToApiVersion(new(1, 0));
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
