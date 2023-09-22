using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiddlewareLayer.Middleware
{
    public class LoggerForMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            // başlangıç log işlemi
            await next.Invoke(context); // yetkilendirme ve diğer işlemlerin tamamlanması
            // logların istenen pathe yazılması

        }
    }
}
