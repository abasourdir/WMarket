using Serilog;
using WMarket.Common.Api.Logging;

namespace WMarket.Operation.Api.Extensions;

public static class LoggerExtensions
{
    public static WebApplicationBuilder AddLogging(this WebApplicationBuilder builder)
    {
        Log.Logger = new LoggerConfiguration()
            .ReadFrom.Configuration(builder.Configuration)
            .Enrich.FromLogContext()
            .Enrich.With<ActivityIdEnricher>()
            .CreateLogger();

        builder.Host.UseSerilog();

        return builder;
    }
}