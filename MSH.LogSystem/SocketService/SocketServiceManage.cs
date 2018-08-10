using Common;
using SuperSocket.SocketBase;
using SuperSocket.SocketEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocketService
{
    public class SocketServiceManage
    {
        private static IBootstrap IBootstrap { get; set; }
        private static readonly string LogServiceConfigFileName = Config.LogServiceConfigFileName;

        public static bool Start()
        {
            IBootstrap = BootstrapFactory.CreateBootstrapFromConfigFile(LogServiceConfigFileName);
            if (!IBootstrap.Initialize())
            {
                Console.WriteLine("日志服务初始化失败");
                Console.ReadKey();
                return false;
            }
            var result = IBootstrap.Start();
            if (result == StartResult.Failed)
            {
                Console.WriteLine("日志服务启动失败!");
                Console.ReadKey();
                return false;
            }
            
            return true;
        }

        public static void Stop()
        {
            if (IBootstrap != null)
                IBootstrap.Stop();
            IBootstrap = null;
        }
    }
}
