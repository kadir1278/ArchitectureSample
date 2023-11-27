using CoreLayer.Utilities.Results.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Net;
using System.Security;

namespace MiddlewareLayer.Middleware
{
    public class GlobalExceptionMiddleware : IMiddleware
    {
        private readonly ILogger<GlobalExceptionMiddleware> _logger;
        private readonly Guid _requestId;
        public GlobalExceptionMiddleware(ILogger<GlobalExceptionMiddleware> logger)
        {
            _logger = logger;
            _requestId = Guid.NewGuid();
        }
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                context.Items["RequestId"] = _requestId;
                _logger.LogInformation(context.Request.Path + " Started Request Numarası : {0}", _requestId);
                await next.Invoke(context);
                _logger.LogInformation(context.Request.Path + " Success RequestId : {0}", _requestId);

            }
            catch (SecurityException ex)
            {
                await context.Response.WriteAsync(JsonConvert.SerializeObject(new ErrorDataResult<string>(ex)));
                _logger.LogCritical(context.Request.Path + " Forbidden RequestId : {0}", _requestId);
            }
            catch (Exception ex)
            {
                await context.Response.WriteAsync(JsonConvert.SerializeObject(new ErrorDataResult<string>(ex)));
                _logger.LogError(context.Request.Path + " Finished Request Numarası : {0}", _requestId);
            }

        }
    }
}
