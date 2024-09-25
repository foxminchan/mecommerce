namespace Ecommerce.EF;

public static class Extensions
{
    public static IHostApplicationBuilder AddPostgresPersistence<TDbContext, TDbSeed>(
        this IHostApplicationBuilder builder,
        string conn,
        IModel? model = null,
        Action<IServiceCollection>? action = null
    )
        where TDbContext : DbContext
        where TDbSeed : class, IDbSeeder<TDbContext>
    {
        builder.Services.AddMigration<TDbContext, TDbSeed>();

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

        action?.Invoke(builder.Services);

        return builder;
    }

    public static IHostApplicationBuilder AddPostgresPersistence<TDbContext>(
        this IHostApplicationBuilder builder,
        string conn,
        IModel? model = null,
        Action<IServiceCollection>? action = null
    )
        where TDbContext : DbContext
    {
        builder.Services.AddMigration<TDbContext>();

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

        action?.Invoke(builder.Services);

        return builder;
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
