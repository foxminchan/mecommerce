using Ecommerce.Constant;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.JsonWebTokens;

namespace Ecommerce.ServiceDefaults.AuthOptions;

public static class Extensions
{
    public static IHostApplicationBuilder AddDefaultAuthentication(
        this IHostApplicationBuilder builder
    )
    {
        var identitySection = builder.Configuration.GetSection(nameof(Identity));

        if (!identitySection.Exists())
        {
            return builder;
        }

        var identity = identitySection.Get<Identity>();

        JsonWebTokenHandler.DefaultInboundClaimTypeMap.Remove("sub");

        builder
            .Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.Authority = identity!.Url;
                options.Audience = identity.Audience;
                options.RequireHttpsMetadata = false;
                options.TokenValidationParameters.ValidIssuers = [identity.Url];
                options.TokenValidationParameters.ValidateAudience = false;
            });

        builder
            .Services.AddAuthorizationBuilder()
            .AddPolicy(
                Authorization.Policies.Admin,
                policy => policy.RequireRole(Authorization.Roles.Admin)
            )
            .AddPolicy(Authorization.Policies.User, policy => policy.RequireAuthenticatedUser());

        return builder;
    }
}
