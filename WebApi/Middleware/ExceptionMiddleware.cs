using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace WebApi.Middleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionMiddleware> _logger;

        public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Algo salió mal: {ex}");
                await HandleExceptionAsync(httpContext, ex);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";
            var errorDetails = new ErrorDetails();

            switch (exception)
            {
                case BusinessRuleException ex:
                    context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                    errorDetails.StatusCode = context.Response.StatusCode;
                    errorDetails.Message = ex.Message;
                    break;
                case KeyNotFoundException ex:
                    context.Response.StatusCode = (int)HttpStatusCode.NotFound;
                    errorDetails.StatusCode = context.Response.StatusCode;
                    errorDetails.Message = ex.Message;
                    break;
                default:
                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    errorDetails.StatusCode = context.Response.StatusCode;
                    errorDetails.Message = "Ocurrió un error interno en el servidor. Por favor, intente de nuevo más tarde.";
                    break;
            }

            return context.Response.WriteAsync(errorDetails.ToString());
        }
    }
}