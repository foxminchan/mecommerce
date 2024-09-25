using Ecommerce.Catalog.Domain.CategoryAggregate;

namespace Ecommerce.Catalog.Features.Categories.Get;

internal sealed class GetCategoryEndpoint
    : IEndpoint<Results<Ok<CategoryDto>, NotFound>, GetCategoryQuery, ISender>
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet(
                "/categories/{id:long}",
                async (ISender sender, long id) => await HandleAsync(new(id), sender)
            )
            .ProducesOk<CategoryDto>()
            .ProducesNotFound()
            .WithOpenApi()
            .WithTags(nameof(Category))
            .MapToApiVersion(new(1, 0));
    }

    public async Task<Results<Ok<CategoryDto>, NotFound>> HandleAsync(
        GetCategoryQuery request,
        ISender sender,
        CancellationToken cancellationToken = default
    )
    {
        var result = await sender.Send(request, cancellationToken);

        return result.Status == ResultStatus.NotFound
            ? TypedResults.NotFound()
            : TypedResults.Ok(result.Value);
    }
}
