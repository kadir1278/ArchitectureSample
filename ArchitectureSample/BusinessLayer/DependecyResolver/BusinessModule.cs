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
            serviceCollection.AddDbContext<SystemContext>(options => options.UseSqlServer(ConfigurationHelper.GetSqlConnectionString()));
            serviceCollection.AddHttpContextAccessor();
            serviceCollection.AddSingleton<IWorker, Worker>();
            serviceCollection.AddSingleton<IValidationRuleDal, EfValidationRuleDal>();

            return ServiceTool.Create(serviceCollection);
        }
    }
}
