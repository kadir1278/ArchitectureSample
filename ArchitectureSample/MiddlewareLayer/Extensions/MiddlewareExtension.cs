using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using MiddlewareLayer.Middleware;

namespace MiddlewareLayer.Extensions
{
    public static class MiddlewareExtension
    {
        public static IApplicationBuilder GlobalFilter(this IApplicationBuilder applicationBuilder)
        {
            applicationBuilder.UseMiddleware<GlobalExceptionMiddleware>();
            applicationBuilder.UseMiddleware<CheckProjectStatusMiddleware>();

            return applicationBuilder;
        }
        public static IServiceCollection AddScopedForMiddleware(this IServiceCollection services)
        {
            services.AddScoped<GlobalExceptionMiddleware>();
            services.AddScoped<CheckProjectStatusMiddleware>();
            return services;
        }
    }
}
