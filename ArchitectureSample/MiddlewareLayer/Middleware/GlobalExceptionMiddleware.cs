using CoreLayer.Utilities.Results.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
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
            }
            catch (FormatException ex)
            {
                await CustomException(context,
                                      ex,
                                      StatusCodes.Status409Conflict,
                                      String.Join(context.Request.Path + " Conflict RequestId : {0}", _requestId),
                                      LogLevel.Information);
            }
            catch (SecurityException ex)
            {
                await CustomException(context,
                                      ex,
                                      StatusCodes.Status403Forbidden,
                                      String.Join(context.Request.Path + " Forbidden RequestId : {0}", _requestId),
                                      LogLevel.Warning);
            }
            catch (ValidationException ex)
            {
                await CustomException(context,
                                      ex,
                                      StatusCodes.Status400BadRequest,
                                      String.Join(context.Request.Path + " Forbidden RequestId : {0}", _requestId),
                                      LogLevel.Information);
            }
            catch (Exception ex)
            {
                await CustomException(context,
                                      ex,
                                      StatusCodes.Status400BadRequest,
                                      String.Join(context.Request.Path + " Finished RequestId : {0}", _requestId),
                                      LogLevel.Error);
            }

        }

        private async Task CustomException(HttpContext context, Exception ex, int statusCodes, string logMessage, LogLevel logLevel)
        {
            context.Response.StatusCode = statusCodes;
            await context.Response.WriteAsync(JsonConvert.SerializeObject(new ErrorDataResult<string>(ex)));
            _logger.Log(logLevel, logMessage);
        }
    }
}
