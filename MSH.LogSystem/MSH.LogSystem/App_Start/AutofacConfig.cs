using Aop.Autofac;
using Autofac;
using Autofac.Extras.DynamicProxy;
using Autofac.Integration.WebApi;
using BusinessLayer.Interface;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;

namespace MSH.LogSystem.App_Start
{
    public class AutofacConfig
    {
        public static void Register(HttpConfiguration config)
        {
            var contatiner = RegisterService();
            contatiner.RegisterWebApiFilterProvider(config);
            config.DependencyResolver = new AutofacWebApiDependencyResolver(contatiner.Build());
        }

        /// <summary>
        /// 注入实现
        /// </summary>
        /// <returns></returns>
        private static ContainerBuilder RegisterService()
        {
            var builder = new ContainerBuilder();
            var baseType = typeof(IDependency);

            Assembly[] assemblies = Directory.GetFiles(AppDomain.CurrentDomain.RelativeSearchPath, "*.dll").Select(Assembly.LoadFrom).ToArray();

            //注册所有的ApiController
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly())
                .PropertiesAutowired()
                .AsImplementedInterfaces()
                .AsSelf();

            //注册所有IDependency
            builder.RegisterAssemblyTypes(assemblies)
                  .Where(t => baseType.IsAssignableFrom(t) && !t.IsAbstract)
                  .AsImplementedInterfaces()
                  .PropertiesAutowired()
                  .InstancePerLifetimeScope()
                  .InterceptedBy(typeof(MethodInterceptor))
                  .EnableInterfaceInterceptors();

            builder.Register(a => new MethodInterceptor());
            //builder.Register(a => new JwtAuthAttribute())
            //    .PropertiesAutowired()
            //    .AsImplementedInterfaces()
            //    .AsSelf();

            return builder;
        }
    }
}