using Asp.Versioning;

namespace Ecommerce.SharedKernel.Versioning;

public static class Extensions
{
    public static IHostApplicationBuilder AddVersioning(this IHostApplicationBuilder builder)
    {
        builder
            .Services.AddApiVersioning(options =>
            {
                options.DefaultApiVersion = new(1, 0);
                options.ApiVersionReader = new UrlSegmentApiVersionReader();
            })
            .AddApiExplorer(options =>
            {
                options.GroupNameFormat = "'v'V";
                options.SubstituteApiVersionInUrl = true;
            });

        return builder;
    }
}
