using System.Net;
using Microsoft.AspNetCore.Mvc;
using StudentManagement.API.Exceptions;

namespace StudentManagement.API.Middleware;

public class ExceptionHandlingMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ExceptionHandlingMiddleware> _logger;

    public ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Unhandled exception occurred while processing {Method} {Path}", context.Request.Method, context.Request.Path);
            
            await HandleExceptionAsync(context, ex);
        }
    }

    private static async Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        var (statusCode, message) = exception switch
        {
            NotFoundException ex => 
                ((int)HttpStatusCode.NotFound, ex.Message),

            ValidationException ex => 
                ((int)HttpStatusCode.BadRequest, ex.Message),

            ConflictException ex => 
                ((int)HttpStatusCode.Conflict, ex.Message),

            _ => 
                ((int)HttpStatusCode.InternalServerError, 
                    "An internal server error occurred.")
        };

        context.Response.ContentType = "application/json";
        context.Response.StatusCode = statusCode;

        var problemDetails = new ProblemDetails
        {
            Title = message,
            Status = statusCode,
            Instance = context.Request.Path
        };

        await context.Response.WriteAsJsonAsync(problemDetails);
    }
}