using SocketService;
using SuperSocket.SocketBase;
using SuperSocket.SocketBase.Command;
using SuperSocket.SocketBase.Protocol;
using SuperSocket.SocketEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using SuperSocket.SocketBase.Config;

namespace SuperSocketServerTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var bootstrap = BootstrapFactory.CreateBootstrapFromConfigFile("LogServiceConfig.config");
            if (!bootstrap.Initialize())
            {
                Console.WriteLine("日志服务初始化失败");
                Console.ReadKey();
                return;
            }

            var result = bootstrap.Start();
            Console.WriteLine($"启动结果：{result}");

            if (result == StartResult.Failed)
            {
                Console.WriteLine("日志服务启动失败!");
                Console.ReadKey();
                return;
            }
            
            Console.Read();
            
            bootstrap.Stop();

            Console.WriteLine("The server was stopped!");
            Console.ReadKey();
        }
    }
}
