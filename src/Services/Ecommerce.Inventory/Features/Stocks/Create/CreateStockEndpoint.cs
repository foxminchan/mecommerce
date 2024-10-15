namespace Ecommerce.Inventory.Features.Stocks.Create;

internal sealed class CreateStockEndpoint : IEndpoint<Created<Guid>, CreateStockCommand, ISender>
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPost(
                "/stocks",
                async (CreateStockCommand request, ISender sender) =>
                    await HandleAsync(request, sender)
            )
            .ProducesCreated<Guid>()
            .ProducesValidationProblem()
            .WithOpenApi()
            .WithTags(nameof(Stock))
            .MapToApiVersion(new(1, 0))
            .RequireAuthorization(Authorization.Policies.Admin);
    }

    public async Task<Created<Guid>> HandleAsync(
        CreateStockCommand request,
        ISender sender,
        CancellationToken cancellationToken = default
    )
    {
        var result = await sender.Send(request, cancellationToken);

        return TypedResults.Created(
            new UrlBuilder()
                .WithVersion()
                .WithResource(nameof(Stocks))
                .WithId(result.Value)
                .Build(),
            result.Value
        );
    }
}
