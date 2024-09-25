namespace Ecommerce.SharedKernel.Model;

public sealed record PagedItems<T>(PagedInfo PagedInfo, List<T> Data);
