using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Net;

namespace MiddlewareLayer.Middleware
{
    public class LoggerForMiddleware : IMiddleware
    {
        private readonly ILogger<LoggerForMiddleware> _logger;
        private readonly EventId _eventId;
        public LoggerForMiddleware(ILogger<LoggerForMiddleware> logger)
        {
            _logger = logger;
            _eventId = new EventId();
        }
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            Guid requestId = Guid.NewGuid();
            // başlangıç log işlemi
            _logger.LogInformation(context.Request.Path + "Started Request Numarası : {0}", requestId);
            await next.Invoke(context); // yetkilendirme ve diğer işlemlerin tamamlanması

            switch (context.Response.StatusCode)
            {
                case (int)HttpStatusCode.OK:
                    _logger.LogInformation(context.Request.Path + "Success RequestId : {0}", requestId);
                    break;
                case (int)HttpStatusCode.Unauthorized:
                    _logger.LogWarning(context.Request.Path + "UnAuthorized RequestId : {0}", requestId);
                    break;
                default:
                    _logger.LogInformation(context.Request.Path + "Finished Request Numarası : {0}", requestId);
                    break;
            }



        }


    }
}
