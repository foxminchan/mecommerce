namespace Ecommerce.Inventory.Features.Stocks.Get;

internal sealed class GetStockEndpoint
    : IEndpoint<Results<Ok<StockDto>, NotFound>, GetStockQuery, ISender>
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet(
                "/stocks/{id:guid}",
                async (Guid id, ISender sender) => await HandleAsync(new(id), sender)
            )
            .ProducesOk<StockDto>()
            .ProducesNotFound()
            .WithOpenApi()
            .WithTags(nameof(Stock))
            .MapToApiVersion(new(1, 0));
    }

    public async Task<Results<Ok<StockDto>, NotFound>> HandleAsync(
        GetStockQuery request,
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
