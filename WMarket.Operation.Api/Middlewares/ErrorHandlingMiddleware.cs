using WMarket.Common.Api.Models.Response;
using WMarket.Common.Models.Enum;
using WMarket.Common.Models.Exceptions;
using WMarket.Operation.Api.Middlewares.Models.Response;

namespace WMarket.Operation.Api.Middlewares;

public class ErrorHandlingMiddleware : IMiddleware
{
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        try
        {
            await next(context);
        }
        catch (BusinessException e)
        {
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
        catch (Exception)
        {
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