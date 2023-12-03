using Microsoft.AspNetCore.Http;
using System.Security;

namespace MiddlewareLayer.Middleware
{
    public class HostFilterMiddleware : IMiddleware
    {
        //private readonly IWorker _worker;
        //public HostFilterMiddleware(IWorker worker)
        //{
        //    _worker = worker;
        //}
        private const string IpErrorMessage = "Access Denied";

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                string requestHost = context.Request.Host.Host.ToLower();
                string[] permittedHost = { "localhost" };

                if (permittedHost.Where(x => x == requestHost).Count() > 0)
                    await next.Invoke(context);
                else
                    throw new SecurityException(IpErrorMessage);

            }
            catch (SecurityException)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }

        }
    }
}
