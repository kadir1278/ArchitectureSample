using AttributeExtensionLayer.MethodAttribute.Interceptors.AutoFac;
using Autofac;
using Autofac.Extras.DynamicProxy;
using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using Castle.DynamicProxy;
using DataAccessLayer.Absctract;
using DataAccessLayer.Concrete;
using EntityLayer.Entity;
using System.Reflection;

namespace BusinessLayer.DependecyResolver
{
    public class AutoFacBusinessModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<EfUserDal>().As<IUserDal>();
            builder.RegisterType<EfValidationRuleDal>().As<IValidationRuleDal>().AsImplementedInterfaces();

            builder.RegisterType<ValidationRulesService>().As<IValidationRulesService>();
            builder.RegisterType<UserService>().As<IUserService>();

            var assembly = Assembly.GetExecutingAssembly();
            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces().EnableInterfaceInterceptors(new ProxyGenerationOptions()
            {
                Selector = new AspectInterceptorSelector(),
            }).SingleInstance();
        }
    }
}
