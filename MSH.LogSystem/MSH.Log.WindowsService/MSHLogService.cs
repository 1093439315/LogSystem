using Common;
using SocketService;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using WebApiService;

namespace MSH.Log.WindowsService
{
    public partial class MSHLogService : ServiceBase
    {
        public const string ServiceAddress = "http://localhost:1345";

        public MSHLogService()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            Logger.Info("准备启动服务！");

            //启动Socket服务
            if (!SocketServiceManage.Start())
            {
                Logger.Info("Socket服务启动失败！");
                this.Stop();
                return;
            }

            //启动WebApi服务
            if (!WebApiServiceManage.SelfHostStart(ServiceAddress))
            {
                Logger.Info("WebApi服务启动失败！");
                this.Stop();
            }

            //启动日志落地服务
            if (!LogToDbService.Start())
            {
                Logger.Info("日志落地服务启动失败!");
                this.Stop();
            }
        }

        protected override void OnStop()
        {
            //终止Socket服务
            SocketServiceManage.Stop();

            //终止WebApi服务
            WebApiServiceManage.SelfHostStop();

            //停止日志落地服务
            LogToDbService.Stop();
        }
    }
}
