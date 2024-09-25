namespace Ecommerce.Identity.Options;

public sealed class AppSettings
{
    public ClientSettings Clients { get; set; } = new();
}
