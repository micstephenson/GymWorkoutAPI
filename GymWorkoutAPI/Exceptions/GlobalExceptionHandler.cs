using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Logging;
using System;

namespace GymWorkoutAPI.Exceptions;

internal sealed class GlobalExceptionHandler : IExceptionHandler
{
    public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
    {
        Console.WriteLine("An unhandled exception occurred.");

        httpContext.Response.StatusCode = exception switch
        {
            WorkoutNotFoundException => StatusCodes.Status404NotFound,
            _ => StatusCodes.Status500InternalServerError
        };

        await httpContext.Response.WriteAsJsonAsync(
            new
            {
                Title = "An error occurred",
                Detail = exception.Message,
                StatusCodes = $"{httpContext.Response.StatusCode} ({ReasonPhrases.GetReasonPhrase(httpContext.Response.StatusCode)})"
            },
            cancellationToken: cancellationToken);

        return true;
    }
}