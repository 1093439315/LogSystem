using Common;
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
            //启动WebApi服务
            if (!WebApiServiceManage.Start(ServiceAddress))
            {
                this.Stop();
            }
            //启动日志落地服务
            //if (LogToDbService.Start())
            //{
            //    Logger.Info("日志落地服务启动成功!");
            //}
        }

        protected override void OnStop()
        {
            //终止WebApi服务
            WebApiServiceManage.Stop();
            //停止日志落地服务
            //LogToDbService.Stop();
        }
    }
}
