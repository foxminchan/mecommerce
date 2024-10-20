﻿namespace Ecommerce.Identity.Options;

public sealed class ClientSettings
{
    public string Catalog { get; set; } = string.Empty;
    public string Media { get; set; } = string.Empty;
    public string Inventory { get; set; } = string.Empty;
    public string Location { get; set; } = string.Empty;
    public string Tax { get; set; } = string.Empty;
}
