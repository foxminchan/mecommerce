using Microsoft.Extensions.Diagnostics.Enrichment;

namespace Ecommerce.SharedKernel.Logging;

/// <summary>
///    ref: https://andrewlock.net/customising-the-new-telemetry-logging-source-generator/
/// </summary>
public sealed class MachineNameEnricher : IStaticLogEnricher
{
    public void Enrich(IEnrichmentTagCollector collector)
    {
        collector.Add("MachineName", Environment.MachineName);
    }
}
