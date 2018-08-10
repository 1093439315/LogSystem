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
            if (!SocketServiceManage.Start())
            {
                Console.WriteLine("服务启动失败！");
            }

            Console.ReadLine();

            SocketServiceManage.Stop();

            Console.WriteLine("The server was stopped!");
            Console.ReadKey();
        }
    }
}
