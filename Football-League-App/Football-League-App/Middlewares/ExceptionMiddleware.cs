using Football_League_App.Exceptions;
using Microsoft.AspNetCore.Mvc.Formatters;
using System.Net;
using System.Net.Mime;
using System.Text.Json;

namespace Football_League_App.Middlewares
{
    public class ExceptionMiddleware
    {
        private readonly ILogger<ExceptionMiddleware> _logger;
        private readonly RequestDelegate _next;

        public ExceptionMiddleware(ILogger<ExceptionMiddleware> logger,
            RequestDelegate next)
        {
            _logger = logger;
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                await HandleExceptionAsync(httpContext, ex);
            }
        }

        private async Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            context.Response.ContentType = MediaTypeNames.Application.Json;
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            CustomException customException = new CustomException()
            {
                StatusCode = context.Response.StatusCode, 
                Message = "Something went wrong. Please try again.",
                Details = "Internal Server Error"
            };
            string serializedCustomException = JsonSerializer.Serialize(customException);
            await context.Response.WriteAsync(serializedCustomException);
        }
    }
}
