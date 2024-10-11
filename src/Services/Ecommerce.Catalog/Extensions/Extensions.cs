using GrpcMediaClient = Ecommerce.Media.Grpc.Media.MediaClient;

namespace Ecommerce.Catalog.Extensions;

internal static class Extensions
{
    public static void AddApplicationServices(this IHostApplicationBuilder builder)
    {
        builder.AddServiceDefaults();

        builder.AddOpenApi();
        builder.AddVersioning();
        builder.AddDefaultAuthentication();
        builder.AddEndpoints(typeof(Program));

        builder.Services.Configure<JsonOptions>(options =>
        {
            options.SerializerOptions.PropertyNameCaseInsensitive = true;
            options.SerializerOptions.Converters.Add(new StringTrimmerJsonConverter());
        });

        builder.Services.AddExceptionHandler<ValidationExceptionHandler>();
        builder.Services.AddExceptionHandler<UniqueConstraintExceptionHandler>();
        builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
        builder.Services.AddProblemDetails();

        builder.Services.AddMediatR(cfg =>
        {
            cfg.RegisterServicesFromAssemblyContaining<Program>();
            cfg.AddOpenBehavior(typeof(ValidationBehavior<,>));
            cfg.AddOpenBehavior(typeof(LoggingBehavior<,>));
            cfg.AddOpenBehavior(typeof(ActivityBehavior<,>));
        });

        builder.Services.AddValidatorsFromAssemblyContaining<Program>(includeInternalTypes: true);

        builder.Services.AddSingleton<IMediaService, MediaService>();
        builder.Services.AddSingleton<IActivityScope, ActivityScope>();
        builder.Services.AddSingleton<CommandHandlerMetrics>();
        builder.Services.AddSingleton<QueryHandlerMetrics>();

        builder.AddPostgresPersistence<CatalogContext, CatalogContextSeed>(
            ServiceName.Database.Catalog,
            CatalogContextModel.Instance,
            options =>
            {
                options.AddScoped(typeof(IReadRepository<>), typeof(CatalogRepository<>));
                options.AddScoped(typeof(IRepository<>), typeof(CatalogRepository<>));
            }
        );

        builder.AddRabbitMqEventBus(
            typeof(Program),
            cfg =>
            {
                cfg.AddEntityFrameworkOutbox<CatalogContext>(o =>
                {
                    o.QueryDelay = TimeSpan.FromSeconds(1);

                    o.UsePostgres();

                    o.UseBusOutbox();
                });
            }
        );

        builder
            .Services.AddGrpcClient<GrpcMediaClient>(o =>
            {
                o.Address = new("https://media-api");
            })
            .AddStandardResilienceHandler();
    }
}
