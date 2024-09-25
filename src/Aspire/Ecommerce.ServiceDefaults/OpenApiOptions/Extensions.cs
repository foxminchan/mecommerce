using MicroElements.Swashbuckle.FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;
using Swashbuckle.AspNetCore.SwaggerUI;

namespace Ecommerce.ServiceDefaults.OpenApiOptions;

public static class Extensions
{
    public static IHostApplicationBuilder AddOpenApi(this IHostApplicationBuilder builder)
    {
        var services = builder.Services;

        services.AddEndpointsApiExplorer();
        services.AddFluentValidationRulesToSwagger();
        services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerGenOptions>();
        services.AddSwaggerGen(options => options.OperationFilter<OpenApiDefaultValues>());

        return builder;
    }

    public static IApplicationBuilder UseDefaultOpenApi(
        this WebApplication app,
        Action<SwaggerOptions>? optsAction = null,
        Action<SwaggerUIOptions>? uiAction = null
    )
    {
        var openApiSection = app.Configuration.GetSection(nameof(OpenApi));

        if (!openApiSection.Exists())
        {
            return app;
        }

        var openApi = openApiSection.Get<OpenApi>();

        app.UseSwagger(options => optsAction?.Invoke(options));

        if (!app.Environment.IsDevelopment())
        {
            return app;
        }

        app.UseSwaggerUI(options =>
        {
            options.DocumentTitle = openApi?.Document.Title;
            options.ApplyVersioning(app);
            options.ApplyAuthorization(openApi);
            uiAction?.Invoke(options);
        });

        app.MapGet("/", () => Results.Redirect("/swagger")).ExcludeFromDescription();

        return app;
    }

    private static void ApplyVersioning(this SwaggerUIOptions options, WebApplication app)
    {
        app.DescribeApiVersions()
            .Select(desc => new
            {
                url = $"/swagger/{desc.GroupName}/swagger.json",
                name = desc.GroupName.ToUpperInvariant(),
            })
            .ToList()
            .ForEach(endpoint => options.SwaggerEndpoint(endpoint.url, endpoint.name));
    }

    private static void ApplyAuthorization(this SwaggerUIOptions options, OpenApi? openApi)
    {
        var auth = openApi?.Auth;

        if (auth is null)
        {
            return;
        }

        options.OAuthClientId(auth.ClientId);
        options.OAuthClientSecret(auth.ClientSecret);
        options.OAuthAppName(auth.AppName);
        options.OAuthUsePkce();
    }
}
