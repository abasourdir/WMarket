using WMarket.Common.Api.Models.Response;
using WMarket.Common.Models.Enum;
using WMarket.Common.Models.Exceptions;
using WMarket.Operation.Api.Middlewares.Models.Response;

namespace WMarket.Operation.Api.Middlewares;

public class ErrorHandlingMiddleware
{
    private readonly ILogger<ErrorHandlingMiddleware> _logger;
    private readonly RequestDelegate _next;

    public ErrorHandlingMiddleware(
        ILogger<ErrorHandlingMiddleware> logger,
        RequestDelegate next)
    {
        _logger = logger;
        _next = next;
    }
    
    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (BusinessException e)
        {
            _logger.LogError(e, e.Message);
            
            var response = new MiddlewareResponse
            {
                Error = new ErrorResponse
                {
                    ErrorCode = e.ErrorCode,
                    Message = e.Message
                }
            };
            
            context.Response.StatusCode = StatusCodes.Status200OK;
            await context.Response.WriteAsJsonAsync(response);
        }
        catch (Exception e)
        {
            _logger.LogError(e, e.Message);
            
            var response = new MiddlewareResponse
            {
                Error = new ErrorResponse
                {
                    ErrorCode = ErrorCode.SystemError,
                    Message = "Something went wrong"
                }
            };
            
            context.Response.StatusCode = StatusCodes.Status500InternalServerError;
            await context.Response.WriteAsJsonAsync(response);
        }
    }
}