using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MiddlewareLayer.Middleware;

namespace MiddlewareLayer.Extensions
{
    public static class MiddlewareExtension
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

        public static IApplicationBuilder GlobalFilter(this IApplicationBuilder applicationBuilder)
        {
            MiddlewareSettings middlewareSettings = configurationRoot.Get<MiddlewareSettings>();

            if (middlewareSettings.GlobalExceptionModel.Status) applicationBuilder.UseMiddleware<GlobalExceptionMiddleware>();
            if (middlewareSettings.HostFilterStatus) applicationBuilder.UseMiddleware<HostFilterMiddleware>();
            if (middlewareSettings.LoggerStatus) applicationBuilder.UseMiddleware<LoggerForMiddleware>();
            if (middlewareSettings.CheckProjectStatus) applicationBuilder.UseMiddleware<CheckProjectStatusMiddleware>();

            return applicationBuilder;
        }
        public static IServiceCollection AddScopedForMiddleware(this IServiceCollection services)
        {
            services.AddScoped<CheckProjectStatusMiddleware>();
            services.AddScoped<GlobalExceptionMiddleware>();
            services.AddScoped<HostFilterMiddleware>();
            services.AddScoped<LoggerForMiddleware>();
            return services;
        }
    }
}
