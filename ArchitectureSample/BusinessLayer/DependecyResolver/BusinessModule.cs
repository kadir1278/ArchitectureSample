using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using CoreLayer.Helper;
using CoreLayer.IoC;
using DataAccessLayer.Absctract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Context;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace BusinessLayer.DependecyResolver
{
    public static class BusinessModule
    {
        public static IServiceCollection LoadModule(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            serviceCollection.AddDbContext<SystemContext>(options => options.UseSqlServer(ConfigurationHelper.GetSqlConnectionString()));
            serviceCollection.AddSingleton<IProjectOwnerService, ProjectOwnerService>();
            serviceCollection.AddSingleton<IAuthenticationService, AuthenticationService>();
            serviceCollection.AddSingleton<IWorker, Worker>();


            return ServiceTool.Create(serviceCollection);
        }
    }
}
