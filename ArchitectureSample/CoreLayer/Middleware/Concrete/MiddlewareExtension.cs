using CoreLayer.Middleware.Abstract;
using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLayer.Middleware.Concrete
{
    public class MiddlewareExtension<TMiddleWare> : IMiddlewareExtension<TMiddleWare> where TMiddleWare : class, IMiddleware, new()
    {
        public static IApplicationBuilder HostFilter(this IApplicationBuilder applicationBuilder)
        {
            return applicationBuilder.UseMiddleware<TMiddleWare>();
        }
    }
}
