﻿namespace Ecommerce.Marten.Configs;

public class MartenConfigs
{
    public const string DefaultSchema = "public";
    public bool UseMetadata = true;
    public string WriteModelSchema { get; set; } = DefaultSchema;
    public string ReadModelSchema { get; set; } = DefaultSchema;
    public DaemonMode DaemonMode { get; set; } = DaemonMode.Solo;
}