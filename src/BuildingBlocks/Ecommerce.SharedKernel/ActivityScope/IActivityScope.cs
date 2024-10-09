﻿namespace Ecommerce.SharedKernel.ActivityScope;

/// <summary>
///     ref: https://github.com/oskardudycz/EventSourcing.NetCore/blob/main/Core/OpenTelemetry/ActivityScope.cs
/// </summary>
public interface IActivityScope
{
    Activity? Start(string name)
    {
        return Start(name, new());
    }

    Activity? Start(string name, StartActivityOptions options);

    Task Run(string name, Func<Activity?, CancellationToken, Task> run, CancellationToken ct)
    {
        return Run(name, run, new(), ct);
    }

    Task Run(
        string name,
        Func<Activity?, CancellationToken, Task> run,
        StartActivityOptions options,
        CancellationToken ct
    );

    Task<TResult> Run<TResult>(
        string name,
        Func<Activity?, CancellationToken, Task<TResult>> run,
        CancellationToken ct
    )
    {
        return Run(name, run, new(), ct);
    }

    Task<TResult> Run<TResult>(
        string name,
        Func<Activity?, CancellationToken, Task<TResult>> run,
        StartActivityOptions options,
        CancellationToken ct
    );
}
