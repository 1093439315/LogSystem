using Common;
using Rabbitmq.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Routing;
using WebApiService;

namespace MSH.LogSystem
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        public const string ServiceAddress = "http://localhost:2345";

        protected void Application_Start()
        {
            Logger.Info("准备启动Web版服务！");
            WebApiServiceManage.WebHostStart();

            //启动通道
            RabbitMqServiceManage.Start();
        }

        protected void Application_End()
        {
            WebApiServiceManage.WebHostStop();
            //关闭通道
            RabbitMqServiceManage.Stop();
        }
    }
}
