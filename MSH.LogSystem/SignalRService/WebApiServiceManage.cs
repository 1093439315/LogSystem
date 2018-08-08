using Common;
using Microsoft.Owin.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApiService
{
    public static class WebApiServiceManage
    {
        private static IDisposable Service;

        public static bool Start(string url)
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

        public static void Stop()
        {
            Service.Dispose();
        }
    }
}
