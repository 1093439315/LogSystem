using Aop.Autofac;
using Autofac;
using Autofac.Extras.DynamicProxy;
using Autofac.Integration.WebApi;
using BusinessLayer.Interface;
using Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;

namespace WebApiService.Core
{
    public class AutofacConfig
    {
        public static void Register(HttpConfiguration config, bool isWeb = false)
        {
            var contatiner = RegisterService(isWeb);
            contatiner.RegisterWebApiFilterProvider(config);
            config.DependencyResolver = new AutofacWebApiDependencyResolver(contatiner.Build());
        }

        /// <summary>
        /// 注入实现
        /// </summary>
        /// <returns></returns>
        private static ContainerBuilder RegisterService(bool isWeb)
        {
            var builder = new ContainerBuilder();
            var baseType = typeof(IDependency);

            string path = "";
            
            if (isWeb)
                path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "bin");
            else
                path = AppDomain.CurrentDomain.BaseDirectory;


            Assembly[] assemblies = Directory.GetFiles(path, "*.dll").Select(Assembly.LoadFrom).ToArray();

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