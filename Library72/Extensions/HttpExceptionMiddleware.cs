using Library72.Application.Common.Exceptions;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Text.Json;

namespace Library72.Extensions;

public class HttpExceptionMiddleware : IMiddleware
{
    private readonly ILogger<HttpExceptionMiddleware> _logger;
    public HttpExceptionMiddleware(ILogger<HttpExceptionMiddleware> logger) => _logger = logger;

    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        try
        {
            await next(context);
        }
        catch (Exception e)
        {
            _logger.LogError(e, e.Message);
            await HandleExceptionAsync(context, e);
        }
    }

    private static async Task HandleExceptionAsync(HttpContext httpContext, Exception exception)
    {
        var statusCode = GetStatusCode(exception);
        var response = new ProblemDetails()
        {
            Status = StatusCodes.Status500InternalServerError,
            Title = "Internal Server Error",
            Detail = "An unexpected error occurred on the server"
        };
        httpContext.Response.ContentType = "application/json";
        httpContext.Response.StatusCode = statusCode;
        await httpContext.Response.WriteAsync(JsonSerializer.Serialize(response));
    }
    private static int GetStatusCode(Exception exception) =>
        exception switch
        {
            NotFoundException => StatusCodes.Status404NotFound,
            _ => StatusCodes.Status500InternalServerError
        };
}
