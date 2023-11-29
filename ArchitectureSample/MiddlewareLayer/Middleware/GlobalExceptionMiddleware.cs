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
            bool IsSuccess = false;
            try
            {
                context.Items["RequestId"] = _requestId;
                _logger.LogInformation(context.Request.Path + " Started RequestId : {0}", _requestId);
                await next.Invoke(context);
                IsSuccess = true;
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
            catch (FluentValidation.ValidationException ex)
            {
                await CustomException(context,
                                      ex,
                                      StatusCodes.Status400BadRequest,
                                      String.Join(context.Request.Path + " Forbidden RequestId : {0}", _requestId),
                                      LogLevel.Trace);
            }
            catch (Exception ex)
            {
                await CustomException(context,
                                      ex,
                                      StatusCodes.Status400BadRequest,
                                      String.Join(context.Request.Path + " Finished RequestId : {0}", _requestId),
                                      LogLevel.Error);
            }
            finally
            {
                if (IsSuccess) _logger.LogInformation(context.Request.Path + " Success RequestId : {0}", _requestId);
            }

        }

        private async Task CustomException(HttpContext context, Exception ex, int statusCodes, string logMessage, LogLevel logLevel)
        {
            context.Response.StatusCode = statusCodes;
            context.Response.ContentType = "application/json";
            await context.Response.WriteAsync(JsonConvert.SerializeObject(new ErrorDataResult<string>(ex)));

            switch (logLevel)
            {
                case LogLevel.Error:
                    _logger.LogError(logMessage);
                    break;
                case LogLevel.Information:
                    _logger.LogInformation(logMessage);
                    break;
                case LogLevel.Trace:
                    _logger.LogTrace(logMessage);
                    break;
                case LogLevel.Warning:
                    _logger.LogWarning(logMessage);
                    break;
                default:
                    _logger.LogInformation(logMessage);
                    break;
            }
        }
    }
}
