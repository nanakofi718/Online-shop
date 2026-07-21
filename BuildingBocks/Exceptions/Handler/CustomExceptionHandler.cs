using FluentValidation;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace BuildingBocks.Exceptions.Handler
{
    public class CustomExceptionHandler(ILogger<CustomExceptionHandler> logger)
        : IExceptionHandler
    {
        public async ValueTask<bool> TryHandleAsync(
            HttpContext context,
            Exception exception,
            CancellationToken cancellationToken)
        {
            logger.LogError(
                exception,
                "Error Message: {exceptionMessage}, Time of occurrence {Time}",
                exception.Message,
                DateTime.UtcNow
            );

            (string Detail, string Title, int StatusCode) details = exception switch
            {
                InternalServerException => (
                    exception.Message,
                    "Internal Server Error",
                    StatusCodes.Status500InternalServerError
                ),

                ValidationException => (
                    exception.Message,
                    "Validation Error",
                    StatusCodes.Status400BadRequest
                ),

                BadRequestException => (
                    exception.Message,
                    "Bad Request",
                    StatusCodes.Status400BadRequest
                ),

                NotFoundException => (
                    exception.Message,
                    "Not Found",
                    StatusCodes.Status404NotFound
                ),

                _ => (
                    "An unexpected error occurred.",
                    "Server Error",
                    StatusCodes.Status500InternalServerError
                )
            };

            context.Response.StatusCode = details.StatusCode;
            context.Response.ContentType = "application/problem+json";

            var problemDetails = new ProblemDetails
            {
                Title = details.Title,
                Detail = details.Detail,
                Status = details.StatusCode,
                Instance = context.Request.Path
            };

            problemDetails.Extensions.Add("traceId", context.TraceIdentifier);

            if (exception is ValidationException validationException)
            {
                problemDetails.Extensions.Add(
                    "validationErrors",
                    validationException.Errors.Select(e => new
                    {
                        field = e.PropertyName,
                        error = e.ErrorMessage
                    })
                );
            }

            await context.Response.WriteAsJsonAsync(problemDetails, cancellationToken);

            return true;
        }
    }
}
