using CoreLayer.IoC;
using Microsoft.Extensions.DependencyInjection;

namespace CoreLayer.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddDependencyResolvers(this IServiceCollection services)
        {
            return ServiceTool.Create(services);
        }
    }
}
