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
    public static class SingletonInjection
    {
        public static IServiceCollection Injection(this IServiceCollection serviceCollection)
        {
            /*
             AddTransient -> her servis isteiğinde oluştur
             AddScoped -> her web request için oluştur
             AddSingleton -> proje başlangıcında bir tane oluştur
             */
            serviceCollection.AddSingleton<SystemContext>();
            serviceCollection.AddSingleton<IUserDal, EfUserDal>();
            serviceCollection.AddSingleton<IAuthenticationService, AuthenticationService>();
            serviceCollection.AddSingleton<IWorker, Worker>();

            return serviceCollection;
        }
    }
}
