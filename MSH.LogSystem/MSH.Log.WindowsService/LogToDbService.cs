using BusinessLayer;
using BusinessLayer.Interface;
using Common;
using Configuration;
using Rabbitmq.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSH.Log.WindowsService
{
    public static class LogToDbService
    {
        private static ILogMQServiceManager manager = new LogMQServiceManager();

        public static bool Start()
        {
            try
            {
                RabbitMqServiceManage.Start();
                manager.StartGetMsg(LogLevel.Info);
                return true;
            }
            catch (Exception ex)
            {
                Logger.Error($"日志落地服务启动失败:{ex}");
                return false;
            }
        }

        public static void Stop()
        {
            RabbitMqServiceManage.Stop();
        }
    }
}
