using Ecommerce.Catalog.Domain.CategoryAggregate;

namespace Ecommerce.Catalog.Features.Categories.List;

internal sealed class ListCategoriesEndpoint
    : IEndpoint<Ok<List<CategoryDto>>, ListCategoriesQuery, ISender>
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet(
                "/categories",
                async (ISender sender, string? name = null) => await HandleAsync(new(name), sender)
            )
            .ProducesOk<List<CategoryDto>>()
            .WithOpenApi()
            .WithTags(nameof(Category))
            .MapToApiVersion(new(1, 0));
    }

    public async Task<Ok<List<CategoryDto>>> HandleAsync(
        ListCategoriesQuery request,
        ISender sender,
        CancellationToken cancellationToken = default
    )
    {
        var result = await sender.Send(request, cancellationToken);

        return TypedResults.Ok(result.Value.ToList());
    }
}
