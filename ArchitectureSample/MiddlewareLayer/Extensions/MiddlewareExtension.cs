using CoreLayer.Entity.Dtos;
using CoreLayer.Helper;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using MiddlewareLayer.Middleware;

namespace MiddlewareLayer.Extensions
{
    public static class MiddlewareExtension
    {
        public static IApplicationBuilder GlobalFilter(this IApplicationBuilder applicationBuilder)
        {

            MiddlewareSettings middlewareSettings = ConfigurationHelper.GetMiddlewareSettings();

           applicationBuilder.UseMiddleware<GlobalExceptionMiddleware>();
            if (middlewareSettings.HostFilterStatus) applicationBuilder.UseMiddleware<HostFilterMiddleware>();
            if (middlewareSettings.CheckProjectStatus) applicationBuilder.UseMiddleware<CheckProjectStatusMiddleware>();

            return applicationBuilder;
        }
        public static IServiceCollection AddScopedForMiddleware(this IServiceCollection services)
        {
            services.AddScoped<GlobalExceptionMiddleware>();
            services.AddScoped<CheckProjectStatusMiddleware>();
            services.AddScoped<HostFilterMiddleware>();
            return services;
        }
    }
}
