using Microsoft.AspNetCore.Diagnostics;
using System.Net;

namespace WebApp.API.Helpers
{
    public class GlobalExceptionHandler : IExceptionHandler
    {
        private readonly ILogger<GlobalExceptionHandler> _logger;
        public GlobalExceptionHandler(ILogger<GlobalExceptionHandler> logger)
        {
            _logger = logger;
        }
        public async ValueTask<bool> TryHandleAsync(
            HttpContext httpContext,
            Exception exception,
            CancellationToken cancellationToken)
        {
            //Принимаем сообщение об ошибке и логируем её
            var exceptionMessage = exception.Message;
            _logger.LogError(
                "Error Message: {exceptionMessage}, Time of occurrence {time}",
                exceptionMessage, DateTime.UtcNow);

            //Своё сообщение об ошибке
            var response = new Response
            {
                Code = "value.invalid" ,
                Message = "invalid"
            };


            httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError; 
            await httpContext.Response.WriteAsJsonAsync(response, cancellationToken);

            return true;
        }

        public class Response
        {
            public string Code { get; set; }

            public string Message { get; set; }
        }
    }
}
