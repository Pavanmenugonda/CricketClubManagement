using CricketClubManagement.Application.Common;
using CricketClubManagement.Application.Common.Exceptions;
using System.Net;
using System.Text.Json;

public sealed class ExceptionMiddleware
{
    private readonly RequestDelegate _next;

    public ExceptionMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (ValidationException ex)
        {
            context.Response.StatusCode = StatusCodes.Status400BadRequest;
            await WriteError(context, ex.Message);
        }
        catch (KeyNotFoundException ex)
        {
            context.Response.StatusCode = StatusCodes.Status404NotFound;
            await WriteError(context, ex.Message);
        }
        catch (Exception)
        {
            context.Response.StatusCode = StatusCodes.Status500InternalServerError;
            await WriteError(context, "An unexpected error occurred.");
        }
    }

    private static Task WriteError(HttpContext context, string message)
    {
        context.Response.ContentType = "application/json";

        var response = ApiResponse<string>.Fail(message);
        return context.Response.WriteAsJsonAsync(response);
    }
}

