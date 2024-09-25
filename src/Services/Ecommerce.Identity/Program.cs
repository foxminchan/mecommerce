var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();

var appSettings = new AppSettings();

builder.Configuration.Bind(appSettings);

builder.Services.AddRazorPages();

builder.AddPostgresPersistence<ApplicationDbContext, UserSeed>(
    ServiceName.Database.Identity,
    ApplicationDbContextModel.Instance
);

builder
    .Services.AddIdentity<ApplicationUser, IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders();

var conn = builder.Configuration.GetConnectionString(ServiceName.Redis);

if (!string.IsNullOrWhiteSpace(conn))
{
    builder
        .Services.AddDataProtection()
        .SetDefaultKeyLifetime(TimeSpan.FromDays(14))
        .SetApplicationName(nameof(Ecommerce))
        .PersistKeysToStackExchangeRedis(
            ConnectionMultiplexer.Connect(conn),
            nameof(DataProtectionProvider)
        );
}

var identityServerBuilder = builder
    .Services.AddIdentityServer(options =>
    {
        options.Authentication.CookieLifetime = TimeSpan.FromHours(2);

        options.Events.RaiseErrorEvents = true;
        options.Events.RaiseInformationEvents = true;
        options.Events.RaiseFailureEvents = true;
        options.Events.RaiseSuccessEvents = true;

        // see https://docs.duendesoftware.com/identityserver/v6/fundamentals/resources/
        options.EmitStaticAudienceClaim = true;

        if (builder.Environment.IsDevelopment())
        {
            options.KeyManagement.Enabled = false;
        }
    })
    .AddInMemoryIdentityResources(Config.GetResources())
    .AddInMemoryApiScopes(Config.GetApiScopes())
    .AddInMemoryClients(Config.GetClients(appSettings.Clients))
    .AddInMemoryApiResources(Config.GetApis())
    .AddAspNetIdentity<ApplicationUser>();

// not recommended for production - you need to store your key material somewhere secure
if (builder.Environment.IsDevelopment())
{
    identityServerBuilder.AddDeveloperSigningCredential();
}

var app = builder.Build();

app.MapDefaultEndpoints();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseStaticFiles();

// This cookie policy fixes login issues with Chrome 80+ using HTTP
app.UseCookiePolicy(new() { MinimumSameSitePolicy = SameSiteMode.Lax });

app.UseRouting();
app.UseIdentityServer();
app.UseAuthorization();

app.MapRazorPages().RequireAuthorization();

app.Run();
