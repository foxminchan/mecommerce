using Ecommerce.Marten;

namespace Ecommerce.Inventory.Extensions;

public static class Extensions
{
    public static void AddApplicationServices(this IHostApplicationBuilder builder)
    {
        builder.AddServiceDefaults();

        builder.AddOpenApi();
        builder.AddVersioning();
        builder.AddEndpoints(typeof(Program));

        builder.Services.Configure<JsonOptions>(options =>
        {
            options.SerializerOptions.PropertyNameCaseInsensitive = true;
            options.SerializerOptions.Converters.Add(new StringTrimmerJsonConverter());
        });

        builder.Services.AddExceptionHandler<ValidationExceptionHandler>();
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

        builder.Services.AddSingleton<IActivityScope, ActivityScope>();
        builder.Services.AddSingleton<CommandHandlerMetrics>();
        builder.Services.AddSingleton<QueryHandlerMetrics>();

        builder.AddPostgresPersistence<InventoryContext>(
            ServiceName.Database.Inventory,
            InventoryContextModel.Instance,
            options =>
            {
                options.AddScoped(typeof(IReadRepository<>), typeof(InventoryRepository<>));
                options.AddScoped(typeof(IRepository<>), typeof(InventoryRepository<>));
            }
        );

        builder.AddRabbitMqEventBus(
            typeof(Program),
            cfg =>
            {
                cfg.AddEntityFrameworkOutbox<InventoryContext>(o =>
                {
                    o.QueryDelay = TimeSpan.FromSeconds(1);

                    o.UsePostgres();

                    o.UseBusOutbox();
                });
            }
        );

        builder.AddMarten(ServiceName.Database.Inventory);
    }
}
