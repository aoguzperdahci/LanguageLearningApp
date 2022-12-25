using System.Net;
using System.Text.Json;

namespace LanguageLearningApp.WebAPI
{
    public class ExceptionMiddleware
    {
        public class ExceptionMiddleware
        {
            private readonly RequestDelegate next;

            public ExceptionMiddleware(RequestDelegate next)
            {
                this.next = next;
            }

            public async Task InvokeAsync(HttpContext httpContext)
            {
                try
                {
                    await next(httpContext);
                }
                catch (ArgumentNullException ex)
                {
                    await HandleExceptionAsync(httpContext, ex);
                }
                catch (Exception ex)
                {
                    await HandleExceptionAsync(httpContext, ex);
                }
            }

            private async Task HandleExceptionAsync(HttpContext context, Exception exception)
            {
                context.Response.ContentType = "application/json";
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

                var message = "Internal Server Error from the custom middleware.";
                var error = new ErrorDetails()
                {
                    StatusCode = context.Response.StatusCode,
                    Message = message + Environment.NewLine + exception.Message.ToString()
                };
                await context.Response.WriteAsync(JsonSerializer.Serialize(error));
            }
        }

        public class ErrorDetails
        {
            public int StatusCode { get; set; }
            public string Message { get; set; }
        }
    }
}
