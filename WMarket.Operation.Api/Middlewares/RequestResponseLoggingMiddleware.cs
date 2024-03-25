using System.Diagnostics;
using Microsoft.Extensions.Options;
using WMarket.Common.Api.Constants;
using WMarket.Common.Extensions;
using WMarket.Common.Models.IOptions;

namespace WMarket.Operation.Api.Middlewares;

public class RequestResponseLoggingMiddleware
{
    private readonly ILogger<RequestResponseLoggingMiddleware> _logger;
    private readonly EndpointLoggingOptions _endpointLoggingOptions;
    private readonly RequestDelegate _next;

    public RequestResponseLoggingMiddleware(
        ILogger<RequestResponseLoggingMiddleware> logger,
        IOptions<EndpointLoggingOptions> endpointLoggingOptions,
        RequestDelegate next)
    {
        _logger = logger;
        _endpointLoggingOptions = endpointLoggingOptions.Value;
        _next = next;
    }
    
    public async Task InvokeAsync(HttpContext context)
    {
        var requestId = context.Request.Headers[Headers.CorrelationId].FirstOrDefault();

        Trace.CorrelationManager.ActivityId =
            !string.IsNullOrWhiteSpace(requestId) && Guid.TryParse(requestId, out var correlationId)
                ? correlationId == Guid.Empty ? Guid.NewGuid() : correlationId
                : Guid.NewGuid();
        
        if (_endpointLoggingOptions.Any(a => a.PathRegex.IsMatch(context.Request.Path.Value ?? string.Empty) && !a.Enabled))
        {
            await _next(context);
            return;
        }
        
        var path = $"{context.Request.Path.Value}{context.Request.QueryString}";

        await LogRequestAsync(context.Request, path);

        var originalBodyStream = context.Response.Body;
        await using var newBodyStream = new MemoryStream();
        context.Response.Body = newBodyStream;
        
        await _next(context);

        await LogResponseAsync(context.Response, path);

        await newBodyStream.CopyToAsync(originalBodyStream);
        context.Response.Body = originalBodyStream;
    }

    private async Task LogRequestAsync(HttpRequest request, string requestPath)
    {
        request.EnableBuffering();
        var jsonBody = await request.Body.ReadAllAndReseekAsync();
        var headers = string.Join(", ", request.Headers.Select(s => $"{s.Key}: {s.Value}"));

        if (string.IsNullOrWhiteSpace(jsonBody))
            jsonBody = "NO BODY";
        
        _logger.LogInformation("[HTTP REQUEST] Method: {Method}, Headers: {Headers}, Path: {Path}, Body: {Body}",
            request.Method,
            headers,
            requestPath,
            jsonBody);
    }

    private async Task LogResponseAsync(HttpResponse response, string requestPath)
    {
        var jsonBody = await response.Body.ReadAllAndReseekAsync();
        
        if (string.IsNullOrWhiteSpace(jsonBody))
            jsonBody = "NO BODY";
        
        _logger.LogInformation("[HTTP RESPONSE] StatusCode: {StatusCode}, Path: {Path}, Body: {Body}",
            response.StatusCode,
            requestPath,
            jsonBody);
    }
}

