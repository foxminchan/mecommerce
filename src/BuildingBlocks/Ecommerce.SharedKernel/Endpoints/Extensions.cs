using Asp.Versioning.Builder;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;

namespace Ecommerce.SharedKernel.Endpoints;

public static class Extensions
{
    public static void AddEndpoints(this IHostApplicationBuilder builder, Type type)
    {
        builder.Services.Scan(scan =>
            scan.FromAssembliesOf(type)
                .AddClasses(classes => classes.AssignableTo<IEndpoint>())
                .AsImplementedInterfaces()
                .WithScopedLifetime()
        );
    }

    public static IApplicationBuilder MapEndpoints(
        this WebApplication app,
        ApiVersionSet? apiVersionSet = null
    )
    {
        var scope = app.Services.CreateScope();

        var endpoints = scope.ServiceProvider.GetRequiredService<IEnumerable<IEndpoint>>();

        IEndpointRouteBuilder builder = apiVersionSet is null
            ? app.MapGroup("/api")
            : app.MapGroup("/api/v{version:apiVersion}").WithApiVersionSet(apiVersionSet);

        foreach (var endpoint in endpoints)
        {
            endpoint.MapEndpoint(builder);
        }

        return app;
    }
}
