using FastEndpoints;
using FastEndpoints.Swagger;

namespace WMarket.Operation.Api.Extensions;

public static class ApiExtensions
{
    /// <summary>
    /// Adds FastEndpoints to the service collection
    /// </summary>
    /// <param name="services"></param>
    /// <returns></returns>
    public static IServiceCollection AddApiServices(this IServiceCollection services)
    {
        services.AddFastEndpoints();
        services.SwaggerDocument(options =>
        {
            options.EnableJWTBearerAuth = false;
            options.MinEndpointVersion = 1;
            options.MaxEndpointVersion = 1;
    
            options.DocumentSettings = document =>
            {
                document.DocumentName = "Marketplace operation API";
                document.Title = "Marketplace operation API v1.0";
                document.Version = "v1";
            };
        });

        return services;
    }

    /// <summary>
    /// Uses FastEndpoints and generates swagger document
    /// </summary>
    /// <param name="app"></param>
    /// <returns></returns>
    public static IApplicationBuilder UseApiServices(this IApplicationBuilder app)
    {
        app.UseFastEndpoints(c =>
        {
            c.Versioning.PrependToRoute = true;
            c.Endpoints.RoutePrefix = "api";
        });
        app.UseSwaggerGen();

        return app;
    }
}