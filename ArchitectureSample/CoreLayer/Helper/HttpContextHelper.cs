using CoreLayer.IoC;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

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
