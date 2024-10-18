using Ecommerce.EF.Transaction;

namespace Ecommerce.EF.Extensions;

public static class Extensions
{
    public static IHostApplicationBuilder AddPostgresPersistence<TDbContext, TDbSeed>(
        this IHostApplicationBuilder builder,
        string conn,
        IModel? model = null,
        Action<IServiceCollection>? action = null,
        bool isPooling = true
    )
        where TDbContext : DbContext, IDatabaseFacade
        where TDbSeed : class, IDbSeeder<TDbContext>
    {
        builder.Services.AddMigration<TDbContext, TDbSeed>();
        AddPostgresDbContext<TDbContext>(builder, conn, model, isPooling);
        builder.Services.AddScoped<IDatabaseFacade>(p => p.GetRequiredService<TDbContext>());
        action?.Invoke(builder.Services);
        return builder;
    }

    public static IHostApplicationBuilder AddPostgresPersistence<TDbContext>(
        this IHostApplicationBuilder builder,
        string conn,
        IModel? model = null,
        Action<IServiceCollection>? action = null,
        bool isPooling = true
    )
        where TDbContext : DbContext, IDatabaseFacade
    {
        builder.Services.AddMigration<TDbContext>();
        AddPostgresDbContext<TDbContext>(builder, conn, model, isPooling);
        builder.Services.AddScoped<IDatabaseFacade>(p => p.GetRequiredService<TDbContext>());
        action?.Invoke(builder.Services);
        return builder;
    }

    private static void AddPostgresDbContext<TDbContext>(
        IHostApplicationBuilder builder,
        string conn,
        IModel? model,
        bool isPooling
    )
        where TDbContext : DbContext
    {
        if (isPooling)
        {
            builder.AddNpgsqlDbContext<TDbContext>(
                conn,
                configureDbContextOptions: dbContextOptionsBuilder =>
                {
                    ConfigureDbContextOptions(
                        dbContextOptionsBuilder,
                        typeof(TDbContext).Assembly.FullName,
                        model
                    );
                }
            );
        }
        else
        {
            builder.Services.AddDbContext<TDbContext>(options =>
            {
                ConfigureDbContextOptions(options, typeof(TDbContext).Assembly.FullName, model);
            });
            builder.EnrichNpgsqlDbContext<TDbContext>();
        }
    }

    private static void ConfigureDbContextOptions(
        DbContextOptionsBuilder dbContextOptionsBuilder,
        string? assembly,
        IModel? model
    )
    {
        ArgumentNullException.ThrowIfNull(assembly);

        dbContextOptionsBuilder
            .UseNpgsql(optionsBuilder =>
            {
                optionsBuilder.MigrationsAssembly(assembly);
                optionsBuilder.EnableRetryOnFailure(15, TimeSpan.FromSeconds(30), null);
            })
            .UseExceptionProcessor()
            .UseSnakeCaseNamingConvention();

        if (model is not null)
        {
            dbContextOptionsBuilder.UseModel(model);
        }
    }
}
