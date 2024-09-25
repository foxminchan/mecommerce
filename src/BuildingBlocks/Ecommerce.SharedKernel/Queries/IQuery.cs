namespace Ecommerce.SharedKernel.Queries;

/// <summary>
///     ref: https://code-maze.com/cqrs-mediatr-fluentvalidation/
/// </summary>
/// <typeparam name="TResponse"></typeparam>
public interface IQuery<out TResponse> : IRequest<TResponse>;
