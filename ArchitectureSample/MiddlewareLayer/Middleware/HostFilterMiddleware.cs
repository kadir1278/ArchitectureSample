using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MiddlewareLayer.Middleware
{
    public class HostFilterMiddleware : IMiddleware
    {
        
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            bool status = false;

            if (status != null)
                await next.Invoke(context);
            else
                context.Response.Redirect("/yetkisiz-erisim");
        }
    }
}
