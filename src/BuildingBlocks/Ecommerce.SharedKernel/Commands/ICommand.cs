namespace Ecommerce.SharedKernel.Commands;

public interface ICommand : ICommand<Result>;

/// <summary>
///     ref: https://code-maze.com/cqrs-mediatr-fluentvalidation/
/// </summary>
/// <typeparam name="TResponse"></typeparam>
public interface ICommand<out TResponse> : IRequest<TResponse>;
