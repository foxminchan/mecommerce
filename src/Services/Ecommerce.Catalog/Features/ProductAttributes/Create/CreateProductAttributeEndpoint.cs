﻿using Ecommerce.Catalog.Domain.ProductAttributeAggregate;

namespace Ecommerce.Catalog.Features.ProductAttributes.Create;

internal sealed class CreateProductAttributeEndpoint
    : IEndpoint<Created<long>, CreateProductAttributeCommand, ISender>
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPost(
                "/product-attributes",
                async (CreateProductAttributeCommand request, ISender sender) =>
                    await HandleAsync(request, sender)
            )
            .ProducesCreated<long>()
            .ProducesValidationProblem()
            .WithOpenApi()
            .WithTags(nameof(ProductAttribute).Humanize(LetterCasing.Title))
            .MapToApiVersion(new(1, 0))
            .RequireAuthorization(Constant.Auth.Policies.Admin);
    }

    public async Task<Created<long>> HandleAsync(
        CreateProductAttributeCommand request,
        ISender sender,
        CancellationToken cancellationToken = default
    )
    {
        var result = await sender.Send(request, cancellationToken);

        return TypedResults.Created($"/api/v1/product-attributes/{result.Value}", result.Value);
    }
}
