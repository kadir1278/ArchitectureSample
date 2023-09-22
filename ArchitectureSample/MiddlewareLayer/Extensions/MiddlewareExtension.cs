using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using MiddlewareLayer.Middleware;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiddlewareLayer.Extensions
{
    public static class MiddlewareExtension
    {
        public static IApplicationBuilder HostFilter(this IApplicationBuilder applicationBuilder)
        {
            return applicationBuilder.UseMiddleware<HostFilterMiddleware>();
        }
    }
}
