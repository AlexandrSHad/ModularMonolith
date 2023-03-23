using System.Collections.Concurrent;
using Humanizer;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using ModularMonolith.Shared.Abstractions.Exceptions;

namespace ModularMonolith.Shared.Infrastructure.Exceptions;

public class ErrorHandlerMiddleware : IMiddleware
{
    private ConcurrentDictionary<Type, string> _codes = new();
    private readonly ILogger<ErrorHandlerMiddleware> _logger;

    public ErrorHandlerMiddleware(ILogger<ErrorHandlerMiddleware> logger)
    {
        _logger = logger;
    }
    
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        try
        {
            await next(context);
        }
        catch (Exception exception)
        {
            var statusCode = 500;
            var code = "error";
            var message = "There was an error.";
            
            _logger.LogError(exception, exception.Message);

            if (exception is CustomException customException)
            {
                // it is also possible to build CustomNotFoundException and show the Id or use other props from it
                code = _codes.GetOrAdd(
                    customException.GetType(),
                    (type) => type.Name.Underscore().Replace("_exception", String.Empty));

                statusCode = 400;
                message = customException.Message;
            }

            context.Response.StatusCode = statusCode;
            // or use ProblemDetails
            // this response does not conform with GET /hosts/{id} NotFound() response
            await context.Response.WriteAsJsonAsync(new { statusCode, code, message }); 
        }
    }
}