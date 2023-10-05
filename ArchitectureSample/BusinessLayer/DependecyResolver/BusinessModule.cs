using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using CoreLayer.Business.Abstract;
using CoreLayer.Business.Concrete;
using CoreLayer.Helper;
using DataAccessLayer.Absctract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Context;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
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


            //serviceCollection.AddDbContext<SystemContext>();=>
            //dboptions işlemi burada yapılmayacağı için adddbcontext yerine addscoped seçildi aralarında bir fark görülmedi

            serviceCollection.AddScoped<SystemContext>();
            serviceCollection.AddSingleton<IAuthenticationService, AuthenticationService>();
            serviceCollection.AddSingleton<IWorker, Worker>();

            return serviceCollection;
        }
    }
}
