﻿using AttributeExtensionLayer.MethodAttribute.Interceptors.AutoFac;
using Autofac;
using Autofac.Extras.DynamicProxy;
using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using Castle.DynamicProxy;
using DataAccessLayer.Absctract;
using DataAccessLayer.Concrete;
using System.Reflection;

namespace BusinessLayer.DependecyResolver
{
    public class AutoFacBusinessModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<TokenHelper>().As<ITokenHelper>();

            builder.RegisterType<EfCompanyDal>().As<ICompanyDal>();
            builder.RegisterType<EfDomainDal>().As<IDomainDal>();
            builder.RegisterType<EfPermissionDal>().As<IPermissionDal>();
            builder.RegisterType<EfProjectDal>().As<IProjectDal>();
            builder.RegisterType<EfProjectDomainActivityStatusHistoryDal>().As<IProjectDomainActivityStatusHistoryDal>();
            builder.RegisterType<EfRoleDal>().As<IRoleDal>();
            builder.RegisterType<EfRolePermissionDal>().As<IRolePermissionDal>();
            builder.RegisterType<EfUserDal>().As<IUserDal>();
            builder.RegisterType<EfUserRoleDal>().As<IUserRoleDal>();
            builder.RegisterType<EfValidationRuleDal>().As<IValidationRuleDal>();


            builder.RegisterType<ValidationRulesService>().As<IValidationRulesService>();
            builder.RegisterType<AuthenticationService>().As<IAuthenticationService>();
            builder.RegisterType<UserService>().As<IUserService>();

            var assembly = Assembly.GetExecutingAssembly();
            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces().EnableInterfaceInterceptors(new ProxyGenerationOptions()
            {
                Selector = new AspectInterceptorSelector(),
            }).SingleInstance();
        }
    }
}
