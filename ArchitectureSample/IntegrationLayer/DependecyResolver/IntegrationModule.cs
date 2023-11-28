using CoreLayer.IoC;
using IntegrationLayer.Business.Abstract;
using IntegrationLayer.Business.Concrete;
using Microsoft.Extensions.DependencyInjection;

namespace IntegrationLayer.DependecyResolver
{
    public static class IntegrationModule
    {
        public static IServiceCollection IntegrationLoadModule(this IServiceCollection serviceCollection)
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
