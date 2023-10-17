using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using CoreLayer.Helper;
using CoreLayer.IoC;
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
            serviceCollection.AddHttpContextAccessor();
            serviceCollection.AddDbContext<SystemContext>(options => options.UseSqlServer(ConfigurationHelper.GetSqlConnectionString()));
            serviceCollection.AddSingleton<ICompanyService, CompanyService>();
            serviceCollection.AddSingleton<IProjectOwnerService, ProjectOwnerService>();
            serviceCollection.AddSingleton<IAuthenticationService, AuthenticationService>();
            serviceCollection.AddSingleton<IUserService, UserService>();
            serviceCollection.AddSingleton<IWorker, Worker>();


            return ServiceTool.Create(serviceCollection);
        }
    }
}
