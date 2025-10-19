using System.Net;

namespace AgendaApi.Extensions
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
        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro capturado no middleware");

                context.Response.ContentType = "application/json";

                context.Response.StatusCode = ex switch
                {
                    NotFoundException => (int)HttpStatusCode.NotFound,
                    ValidationException => (int)HttpStatusCode.BadRequest,
                    BusinessException => (int)HttpStatusCode.UnprocessableEntity,
                    _ => (int)HttpStatusCode.InternalServerError
                };

                await context.Response.WriteAsJsonAsync(new
                {
                    error = ex.Message,
                    status = context.Response.StatusCode
                });
            }
        }
    }
}
