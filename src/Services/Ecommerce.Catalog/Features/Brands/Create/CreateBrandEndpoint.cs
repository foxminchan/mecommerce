using Ecommerce.Catalog.Domain.BrandAggregate;

namespace Ecommerce.Catalog.Features.Brands.Create;

internal sealed class CreateBrandEndpoint : IEndpoint<Created<long>, CreateBrandCommand, ISender>
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPost(
                "/brands",
                async (CreateBrandCommand request, ISender sender) =>
                    await HandleAsync(request, sender)
            )
            .ProducesCreated<long>()
            .ProducesValidationProblem()
            .ProducesConflictProblem()
            .WithOpenApi()
            .WithTags(nameof(Brand))
            .MapToApiVersion(new(1, 0));
    }

    public async Task<Created<long>> HandleAsync(
        CreateBrandCommand request,
        ISender sender,
        CancellationToken cancellationToken = default
    )
    {
        var result = await sender.Send(request, cancellationToken);

        return TypedResults.Created($"/api/v1/brands/{result.Value}", result.Value);
    }
}
