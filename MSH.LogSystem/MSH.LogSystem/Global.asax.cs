using MSH.LogSystem.App_Start;
using Rabbitmq.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Routing;

namespace MSH.LogSystem
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            GlobalConfiguration.Configure(AutofacConfig.Register);
            //启动通道
            RabbitMqServiceManage.Start();
        }

        protected void Application_End()
        {
            //关闭通道
            RabbitMqServiceManage.Stop();
        }
    }
}
