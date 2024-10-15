using Marten.AspNetCore;

namespace Ecommerce.Inventory.Features.Stocks.GetHistory;

internal sealed class GetStockHistoryEndpoint : IEndpoint<Ok, Guid, HttpContext, IQuerySession>
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet(
                "/stocks/history",
                async (HttpContext context, IQuerySession querySession, Guid id) =>
                    await HandleAsync(id, context, querySession)
            )
            .ProducesOk()
            .WithOpenApi()
            .WithTags(nameof(Stock))
            .MapToApiVersion(new(1, 0))
            .RequireAuthorization(Authorization.Policies.Admin);
    }

    public async Task<Ok> HandleAsync(
        Guid id,
        HttpContext context,
        IQuerySession querySession,
        CancellationToken cancellationToken = default
    )
    {
        await querySession.Json.WriteById<StockHistory>(id, context);
        return TypedResults.Ok();
    }
}
