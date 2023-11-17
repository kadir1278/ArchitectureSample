using CoreLayer.IoC;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLayer.Helper
{
    public static class HttpContextHelper
    {
        public static HttpContext GetHttpContext()
        {
            IHttpContextAccessor httpContextAccessor = ServiceTool.ServiceProvider.GetService<IHttpContextAccessor>();
            return httpContextAccessor.HttpContext;
        }
    }
}
