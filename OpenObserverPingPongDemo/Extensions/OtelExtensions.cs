using OpenTelemetry.Metrics;
using OpenTelemetry.Resources;
using OpenTelemetry.Trace;

namespace OpenObserverPingPongDemo.Extensions;

public static class OtelExtensions
{
    public static void AddOpenTelemetryServices(this IServiceCollection services)
    {
        services.AddOpenTelemetry()
             .ConfigureResource(resource => resource
                 .AddService(serviceName: "OpenObserverPingPongDemo", serviceVersion: "1.0.0"))
             .WithTracing(tracing => tracing
                 .AddAspNetCoreInstrumentation()
                 .AddHttpClientInstrumentation()
                 .AddOtlpExporter())
             .WithMetrics(metrics => metrics
                 .AddAspNetCoreInstrumentation()
                 .AddHttpClientInstrumentation()
                 .AddRuntimeInstrumentation()
                 .AddProcessInstrumentation()
                 .AddOtlpExporter());
    }
}
