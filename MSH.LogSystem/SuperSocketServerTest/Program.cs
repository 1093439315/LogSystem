using SocketService.Core;
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
using Rabbitmq.Core;
using BusinessLayer.Interface;
using BusinessLayer;
using Configuration;

namespace SuperSocketServerTest
{
    class Program
    {
        private static ILogMQServiceManager manager = new LogMQServiceManager();
        static void Main(string[] args)
        {
            RabbitMqServiceManage.Start();
            if (!SocketServiceManage.Start())
            {
                Console.WriteLine("服务启动失败！");
            }

            manager.StartGetMsg(LogLevel.Info);

            Console.ReadLine();

            SocketServiceManage.Stop();

            Console.WriteLine("The server was stopped!");
            Console.ReadKey();
        }
    }
}
