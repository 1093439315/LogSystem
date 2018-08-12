using BusinessLayer;
using BusinessLayer.Interface;
using Common;
using Configuration;
using Rabbitmq.Core;
using SocketService.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using WebApiService.Core;

namespace MSH.Log.WindowsService
{
    public partial class MSHLogService : ServiceBase
    {
        public string ServiceAddress = $"http://{Config.ServiceHost}:{Config.ServicePort}";
        private static ILogMQServiceManager manager = new LogMQServiceManager();

        public MSHLogService()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            Logger.Info("准备启动服务！");

            //创建RabbitMq队列连接
            if (!RabbitMqServiceManage.Start())
            {
                Logger.Info("连接RabbitMq队列失败！");
                this.Stop();
                return;
            }

            //启动日志落地服务 用于将日志从队列转移到Db
            manager.StartGetMsg(LogLevel.Info);

            //启动Socket服务 用户接收客户端消息
            if (!SocketServiceManage.Start())
            {
                Logger.Info("Socket服务启动失败！");
                this.Stop();
                return;
            }
            
            //启动WebApi服务 用户提供管理端接口
            if (!WebApiServiceManage.SelfHostStart(ServiceAddress))
            {
                Logger.Info("WebApi服务启动失败！");
                this.Stop();
            }
            
        }

        protected override void OnStop()
        {
            //终止队列连接
            RabbitMqServiceManage.Stop();

            //终止Socket服务
            SocketServiceManage.Stop();
            
            //终止WebApi服务
            WebApiServiceManage.SelfHostStop();
        }
    }
}
