namespace Ecommerce.EF.Transaction;

public sealed class TxBehavior<TRequest, TResponse>(
    IDatabaseFacade databaseFacade,
    ILogger<TxBehavior<TRequest, TResponse>> logger
) : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
{
    public async Task<TResponse> Handle(
        TRequest request,
        RequestHandlerDelegate<TResponse> next,
        CancellationToken cancellationToken
    )
    {
        var txAttribute = request.GetType().GetCustomAttribute<TxScope>();

        if (txAttribute is null)
        {
            logger.LogDebug(
                "[{Behavior}] No transaction scope defined for {Request}",
                nameof(TxBehavior<TRequest, TResponse>),
                request.GetType().Name
            );
            return await next();
        }

        var strategy = databaseFacade.Database.CreateExecutionStrategy();

        return await strategy.ExecuteAsync(async () =>
        {
            await using var transaction = await databaseFacade.Database.BeginTransactionAsync(
                IsolationLevel.ReadCommitted,
                cancellationToken
            );

            logger.LogWarning(
                "[{Behavior}] Transaction started for {Request}",
                nameof(TxBehavior<TRequest, TResponse>),
                request.GetType().Name
            );

            var response = await next();

            await transaction.CommitAsync(cancellationToken);

            return response;
        });
    }
}
