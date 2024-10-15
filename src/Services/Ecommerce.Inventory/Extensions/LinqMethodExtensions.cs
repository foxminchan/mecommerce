namespace Ecommerce.Inventory.Extensions;

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
}
