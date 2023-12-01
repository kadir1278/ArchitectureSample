using CoreLayer.Business.Abstract;
using CoreLayer.Business.Concrete;
using CoreLayer.IoC;
using Microsoft.Extensions.DependencyInjection;

namespace CoreLayer.DependecyResolver
{
    public static class IntegrationModule
    {
        public static IServiceCollection CoreModule(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddSingleton<ICookieService, CookieService>();
            serviceCollection.AddSingleton<IFileService, FileService>();
            serviceCollection.AddSingleton<IMailService, MailService>();
            serviceCollection.AddSingleton<INetherlandRdwService, NetherlandRdwService>();
            serviceCollection.AddSingleton<ITCMBExchangeService, TCMBExchangeService>();

            return ServiceTool.Create(serviceCollection);
        }
    }
}
