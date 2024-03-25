using System.Diagnostics;
using Serilog.Core;
using Serilog.Events;

namespace WMarket.Common.Api.Logging.Enrichers;

public class ActivityIdEnricher : ILogEventEnricher
{
    public void Enrich(LogEvent logEvent, ILogEventPropertyFactory propertyFactory)
    {
        logEvent.AddPropertyIfAbsent(new ("CorrelationId", new ScalarValue(Trace.CorrelationManager.ActivityId)));
    }
}