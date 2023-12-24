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
            catch (Exception ex)
            {
                await CustomException(context, ex);
            }
            finally
            {
                if (IsSuccess) _logger.LogInformation(context.Request.Path + " Success RequestId : {0}", _requestId);
                else _logger.LogWarning(context.Request.Path + " Exception RequestId : {0}", _requestId);
            }

        }

        private async Task CustomException(HttpContext context, Exception ex)
        {

            Type exceptionType = ex.GetType();
            int statusCodes = StatusCodes.Status400BadRequest;

            if (exceptionType == typeof(ValidationException)) statusCodes = StatusCodes.Status400BadRequest;
            if (exceptionType == typeof(FluentValidation.ValidationException)) statusCodes = StatusCodes.Status400BadRequest;
            if (exceptionType == typeof(FormatException)) statusCodes = StatusCodes.Status409Conflict;
            if (exceptionType == typeof(SecurityException))
            {
                statusCodes = StatusCodes.Status403Forbidden;
            }
            if (exceptionType == typeof(UnauthorizedAccessException)) statusCodes = StatusCodes.Status401Unauthorized;
            if (exceptionType == typeof(ApplicationException)) statusCodes = StatusCodes.Status400BadRequest;

            context.Response.StatusCode = statusCodes;
            context.Response.ContentType = "application/json";
            await context.Response.WriteAsync(JsonConvert.SerializeObject(new ErrorDataResult<string>(ex)));
        }
    }
}
