using Common;
using MapperConfiguration;
using Microsoft.Owin.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace WebApiService
{
    public static class WebApiServiceManage
    {
        private static IDisposable Service;

        public static bool SelfHostStart(string url)
        {
            try
            {
                Service = WebApp.Start<Startup>(url);
                return true;
            }
            catch (Exception ex)
            {
                Logger.Error($"启动WebApi服务失败:{ex}");
                return false;
            }
        }

        public static void SelfHostStop()
        {
            Service.Dispose();
        }

        public static bool WebHostStart()
        {
            try
            {
                GlobalConfiguration.Configure(config => WebApiConfig.Register(config));
                GlobalConfiguration.Configure(config => AutofacConfig.Register(config, true));
                GlobalConfiguration.Configure(config => SwaggerConfig.Register(config, true));
                MapperConfig.Initial();
                return true;
            }
            catch (Exception ex)
            {
                Logger.Info($"服务启动失败:{ex}");
                return false;
            }
        }

        public static void WebHostStop()
        {
        }
    }
}
