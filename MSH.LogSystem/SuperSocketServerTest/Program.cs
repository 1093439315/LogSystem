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
            //var config = ConfigurationManager.GetSection("superSocket") as IConfigurationSource;
            var bootstrap = BootstrapFactory.CreateBootstrapFromConfigFile("LogServiceConfig.config");
            //var bootstrap = BootstrapFactory.CreateBootstrap(config);
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

            //Stop the appServer
            bootstrap.Stop();

            Console.WriteLine("The server was stopped!");
            Console.ReadKey();
        }

        private static void LogServer_SessionClosed(LogSession session, CloseReason value)
        {
            Console.WriteLine("客户端关闭");
        }

        private static void LogServer_NewRequestReceived(LogSession session, StringRequestInfo requestInfo)
        {
            Console.WriteLine("接收到请求！");
            switch (requestInfo.Key.ToUpper())
            {
                case ("ECHO"):
                    session.Send(requestInfo.Body);
                    break;

                case ("ADD"):
                    session.Send(requestInfo.Parameters.Select(p => Convert.ToInt32(p)).Sum().ToString());
                    break;

                case ("MULT"):
                    var result = 1;
                    foreach (var factor in requestInfo.Parameters.Select(p => Convert.ToInt32(p)))
                    {
                        result *= factor;
                    }
                    session.Send(result.ToString());
                    break;
            }
        }

        private static void LogServer_NewSessionConnected(LogSession session)
        {
            Console.WriteLine("客户端已连接");
            //session.Send("哈哈");
        }
    }
}
