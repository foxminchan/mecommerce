namespace Ecommerce.Identity.Configuration;

public static class Config
{
    // Identity resources are data like user ID, name, or email address of a user
    // see: http://docs.identityserver.io/en/release/configuration/resources.html
    public static IEnumerable<IdentityResource> GetResources()
    {
        return [new IdentityResources.OpenId(), new IdentityResources.Profile()];
    }

    // ApiScope is used to protect the API
    // The effect is the same as that of API resources in IdentityServer 3.x
    public static IEnumerable<ApiScope> GetApiScopes()
    {
        return
        [
            new("catalog", "Catalog Service"),
            new("media", "Media Service"),
            new("inventory", "Inventory Service"),
            new("location", "Location Service"),
        ];
    }

    // ApiResources define the apis in your system
    public static IEnumerable<ApiResource> GetApis()
    {
        return
        [
            new("catalog", "Catalog Service"),
            new("media", "Media Service"),
            new("inventory", "Inventory Service"),
            new("location", "Location Service"),
        ];
    }

    // client want to access resources (aka scopes)
    public static IEnumerable<Client> GetClients(ClientSettings client)
    {
        return
        [
            new()
            {
                ClientId = "catalogswaggerui",
                ClientName = "Catalog Swagger UI",
                ClientSecrets = { new("secret".Sha256()) },
                AllowedGrantTypes = GrantTypes.Code,
                RequireConsent = false,
                RequirePkce = true,
                AllowAccessTokensViaBrowser = true,
                RedirectUris = { $"{client.Catalog}/swagger/oauth2-redirect.html" },
                PostLogoutRedirectUris = { $"{client.Catalog}/swagger/" },
                AllowedCorsOrigins = { client.Catalog },
                AllowedScopes = { "catalog" },
            },
            new()
            {
                ClientId = "mediaswaggerui",
                ClientName = "Media Swagger UI",
                ClientSecrets = { new("secret".Sha256()) },
                AllowedGrantTypes = GrantTypes.Code,
                RequireConsent = false,
                RequirePkce = true,
                AllowAccessTokensViaBrowser = true,
                RedirectUris = { $"{client.Media}/swagger/oauth2-redirect.html" },
                PostLogoutRedirectUris = { $"{client.Media}/swagger/" },
                AllowedCorsOrigins = { client.Media },
                AllowedScopes = { "media" },
            },
            new()
            {
                ClientId = "inventoryswaggerui",
                ClientName = "Inventory Swagger UI",
                ClientSecrets = { new("secret".Sha256()) },
                AllowedGrantTypes = GrantTypes.Code,
                RequireConsent = false,
                RequirePkce = true,
                AllowAccessTokensViaBrowser = true,
                RedirectUris = { $"{client.Inventory}/swagger/oauth2-redirect.html" },
                PostLogoutRedirectUris = { $"{client.Inventory}/swagger/" },
                AllowedCorsOrigins = { client.Inventory },
                AllowedScopes = { "inventory" },
            },
            new()
            {
                ClientId = "locationswaggerui",
                ClientName = "Location Swagger UI",
                ClientSecrets = { new("secret".Sha256()) },
                AllowedGrantTypes = GrantTypes.Code,
                RequireConsent = false,
                RequirePkce = true,
                AllowAccessTokensViaBrowser = true,
                RedirectUris = { $"{client.Location}/swagger/oauth2-redirect.html" },
                PostLogoutRedirectUris = { $"{client.Location}/swagger/" },
                AllowedCorsOrigins = { client.Location },
                AllowedScopes = { "location" },
            },
        ];
    }
}
