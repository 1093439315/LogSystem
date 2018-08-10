using Common;
using SuperSocket.SocketBase;
using SuperSocket.SocketEngine;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocketService.Core
{
    public class SocketServiceManage
    {
        private static IBootstrap IBootstrap { get; set; }
        private static readonly string LogServiceConfigFileName = Config.LogServiceConfigFileName;

        public static bool Start()
        {
            try
            {
                var configFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, LogServiceConfigFileName);
                Logger.Info(configFilePath);
                IBootstrap = BootstrapFactory.CreateBootstrapFromConfigFile(configFilePath);
                if (!IBootstrap.Initialize())
                {
                    Console.WriteLine("日志服务初始化失败");
                    Logger.Error("日志服务启动失败！");
                    return false;
                }
                var result = IBootstrap.Start();
                if (result == StartResult.Failed)
                {
                    Console.WriteLine("日志服务启动失败!");
                    Logger.Error("日志服务启动失败！");
                    return false;
                }
                return true;
            }
            catch (Exception ex)
            {
                Logger.Error($"启动日志Socket服务失败:{ex}");
                return false;
            }
        }

        public static void Stop()
        {
            if (IBootstrap != null)
                IBootstrap.Stop();
            IBootstrap = null;
        }
    }
}
