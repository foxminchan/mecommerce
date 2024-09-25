namespace Ecommerce.Inventory.Extensions;

public static class Extensions
{
    public static void AddApplicationServices(this IHostApplicationBuilder builder)
    {
        builder.AddServiceDefaults();

        builder.AddOpenApi();
        builder.AddVersioning();
        builder.AddEndpoints(typeof(Program));
    }
}
