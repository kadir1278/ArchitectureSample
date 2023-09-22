using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace MiddlewareLayer.Middleware
{
    public class GlobalExceptionMiddleware : IMiddleware
    {
     
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            await next.Invoke(context);

            string unauthorizedPath = "/yetkisiz-erisim";
            switch (context.Response.StatusCode)
            {
                case (int)HttpStatusCode.Unauthorized:
                    context.Response.Redirect(unauthorizedPath);
                    break;
                default:
                    break;
            }
        }
    }
}
