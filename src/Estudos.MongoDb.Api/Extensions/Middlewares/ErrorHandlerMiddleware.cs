using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;

namespace Estudos.MongoDb.Api.Extensions.Middlewares;

public class ErrorHandlerMiddleware
{
    private readonly RequestDelegate _next;

    private readonly ILogger<ErrorHandlerMiddleware> _logger;

    private readonly IWebHostEnvironment _environment;

    public ErrorHandlerMiddleware(RequestDelegate next, ILogger<ErrorHandlerMiddleware> logger, IWebHostEnvironment environment)
    {
        _next = next;
        _logger = logger;
        _environment = environment;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception e)
        {
            await ResponseErrorAsync(context, e);
        }
    }

    private async Task ResponseErrorAsync(HttpContext context, Exception exception)
    {
        _logger.LogError(exception, $"error in [{nameof(ErrorHandlerMiddleware)}]");

        var response = context.Response;
        response.ContentType = MediaTypeNames.Application.Json;
        response.StatusCode = StatusCodes.Status500InternalServerError;
        string message = "Ocorreu um erro na sua requisição. Por favor, tente novamente";
        var problem = new ProblemDetails
        {
            Title = "Internal Server Error",
            Status = response.StatusCode,
            Detail = _environment.IsDevelopment() ? exception.Message : message,
            Instance = context.Request.HttpContext.Request.Path,
            Type = $"https://developer.mozilla.org/pt-BR/docs/Web/HTTP/Status/{response.StatusCode}"
        };

        await response.WriteAsJsonAsync(problem);
    }
}