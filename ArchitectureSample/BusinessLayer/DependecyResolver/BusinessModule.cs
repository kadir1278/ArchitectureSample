using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.Absctract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Context;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            serviceCollection.AddScoped<SystemContext>();
            serviceCollection.AddScoped<IUserDal, EfUserDal>();
            serviceCollection.AddScoped<IAuthenticationService, AuthenticationService>();
            serviceCollection.AddScoped<IWorker, Worker>();

            return serviceCollection;
        }
    }
}
