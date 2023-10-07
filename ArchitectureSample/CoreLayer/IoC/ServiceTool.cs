using Microsoft.Extensions.DependencyInjection;

namespace CoreLayer.IoC
{
    public class ServiceTool
    {
        public static IServiceProvider ServiceProvider { get; set; } 
        public static IServiceCollection Create(IServiceCollection services)
        {
            ServiceProvider = services.BuildServiceProvider();
            return services;
        }

    }
}
