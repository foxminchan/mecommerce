using Ecommerce.EF.Transaction;
using Microsoft.Extensions.Configuration;

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
                    dbContextOptionsBuilder
                        .UseNpgsql(optionsBuilder =>
                        {
                            optionsBuilder.MigrationsAssembly(typeof(TDbContext).Assembly.FullName);
                            optionsBuilder.EnableRetryOnFailure(15, TimeSpan.FromSeconds(30), null);
                        })
                        .UseExceptionProcessor()
                        .UseSnakeCaseNamingConvention();

                    if (model is not null)
                    {
                        dbContextOptionsBuilder.UseModel(model);
                    }
                }
            );
        }
        else
        {
            builder.Services.AddDbContext<TDbContext>(options =>
            {
                options.UseNpgsql(
                    builder.Configuration.GetConnectionString(conn),
                    optionsBuilder =>
                    {
                        optionsBuilder.MigrationsAssembly(typeof(TDbContext).Assembly.FullName);
                        optionsBuilder.EnableRetryOnFailure(15, TimeSpan.FromSeconds(30), null);
                    }
                );
                options.UseExceptionProcessor();
                options.UseSnakeCaseNamingConvention();

                if (model is not null)
                {
                    options.UseModel(model);
                }
            });
            builder.EnrichNpgsqlDbContext<TDbContext>();
        }
    }
}
