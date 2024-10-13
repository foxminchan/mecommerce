namespace Ecommerce.Catalog.Extensions;

public static class LinqMethodExtensions
{
    public static async Task<Dictionary<TKey, TResult?>> ToDictionaryAsync<T, TKey, TResult>(
        this IEnumerable<T> items,
        Func<T, TKey> keySelector,
        Func<T, Task<TResult?>> resultSelector,
        CancellationToken cancellationToken
    )
        where TKey : notnull
    {
        var tasks = items.Select(async item =>
        {
            var result = await resultSelector(item);
            return (Key: keySelector(item), Result: result);
        });

        var results = await Task.WhenAll(tasks);

        return results.ToDictionary(x => x.Key, x => x.Result);
    }

    public static async Task<(TResult? firstResult, List<TResult> taskResults)> GetFirstAsync<
        TSource,
        TResult
    >(
        this TSource source,
        Func<TSource, Task<TResult?>> firstTaskSelector,
        Func<TSource, IEnumerable<Task<TResult?>>> taskSelector,
        CancellationToken cancellationToken
    )
    {
        var firstTask = firstTaskSelector(source);

        var tasks = taskSelector(source).ToList();

        await Task.WhenAll(firstTask, Task.WhenAll(tasks));

        var firstResult = await firstTask;

        var taskResults = tasks
            .Select(x => x.Result)
            .Where(x => x is not null)
            .Select(x => x!)
            .ToList();

        return (firstResult, taskResults);
    }
}
