using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

namespace MiddlewareLayer.Middleware
{
    public class HostFilterMiddleware : IMiddleware
    {
        #region Constructor
        private static IConfigurationRoot _configurationRoot;
        private static IConfigurationRoot configurationRoot
        {
            get
            {
                string jsonFile = "MiddlewareSettings.json";

                if (_configurationRoot == null)
                    _configurationRoot = new ConfigurationBuilder()
                        .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                        .AddJsonFile(jsonFile)
                        .Build();

                return _configurationRoot;
            }
        }
        #endregion

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                string unauthorizedAccessPath = configurationRoot.GetSection("UnauthorizedAccessPath").Get<string>();
                if (context.Request.Path == unauthorizedAccessPath)
                    await next.Invoke(context);
                else
                {
                    string requestHost = context.Request.Host.Host.ToLower();
                    string[] permittedHost = configurationRoot.GetSection("PermittedHosts").Get<string[]>();

                    if (permittedHost.Where(x => x == requestHost).Count() > 0)
                        await next.Invoke(context);
                    else
                        context.Response.Redirect(unauthorizedAccessPath);

                }
            }
            catch (Exception ex)
            {
                await context.Response.WriteAsync($"{ex.Message}");
            }

        }
    }
}
