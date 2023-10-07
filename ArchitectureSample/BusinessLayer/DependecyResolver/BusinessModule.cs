using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using CoreLayer.Helper;
using DataAccessLayer.Absctract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace BusinessLayer.DependecyResolver
{
    public static class BusinessModule
    {
        public static IServiceCollection LoadModule(this IServiceCollection serviceCollection)
        {
            /*
             AddTransient -> her servis isteiğinde oluştur
             AddScoped -> her web request için oluştur
             AddSingleton -> proje başlangıcında bir tane oluştur
             */

            // transaction ve loglama işlemleri sebebi ile scoped ile kullanılmalıdır.


            serviceCollection.AddDbContext<SystemContext>(options => options.UseSqlServer(ConfigurationHelper.GetSqlConnectionString()));
            serviceCollection.AddSingleton<IAuthenticationService, AuthenticationService>();
            serviceCollection.AddSingleton<IWorker, Worker>();

            return serviceCollection;
        }
    }
}
