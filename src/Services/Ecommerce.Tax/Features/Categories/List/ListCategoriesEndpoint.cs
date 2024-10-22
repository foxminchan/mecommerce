using Ecommerce.Tax.Domain.CategoryAggregate;

namespace Ecommerce.Tax.Features.Categories.List;

internal sealed class ListCategoriesEndpoint
    : IEndpoint<Ok<List<CategoryDto>>, ListCategoriesQuery, ISender>
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet(
                "/categories",
                async ([AsParameters] ListCategoriesQuery query, ISender sender) =>
                    await HandleAsync(query, sender)
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
