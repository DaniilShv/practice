using System.Net;
using System.Text.Json;

namespace BankApi.Middlewares
{
    public class ExceptionHandlingMiddleware
    {
        RequestDelegate _next;

        ILogger<ExceptionHandlingMiddleware> _logger;

        public ExceptionHandlingMiddleware(RequestDelegate next, 
            ILogger<ExceptionHandlingMiddleware> logger)
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
            catch (Exception exc)
            {
                await ExceptionHandlerAsync(exc, context, HttpStatusCode.InternalServerError);
            }
        }

        async Task ExceptionHandlerAsync(Exception exc, HttpContext http, HttpStatusCode code)
        {
            http.Response.ContentType = "application/json";
            http.Response.StatusCode = (int)code;

            var message = JsonSerializer.Serialize(new
            {
                StatusCode = code,
                Message = exc.Message
            });

            await http.Response.WriteAsync(message);
        }
    }
}
