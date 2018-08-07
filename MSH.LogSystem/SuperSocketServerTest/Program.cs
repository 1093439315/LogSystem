using SocketService;
using SuperSocket.SocketBase;
using SuperSocket.SocketBase.Command;
using SuperSocket.SocketBase.Protocol;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperSocketServerTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var logServer = new LogServer();
            logServer.NewSessionConnected += LogServer_NewSessionConnected;
            //logServer.NewRequestReceived += LogServer_NewRequestReceived;
            logServer.SessionClosed += LogServer_SessionClosed;
            if (!logServer.Setup(2012))
            {
                Console.WriteLine("日志服务启动失败！");
                Console.ReadLine();
                return;
            }

            if (!logServer.Start())
            {
                Console.WriteLine("日志服务启动失败");
                Console.ReadKey();
                return;
            }

            Console.WriteLine("按任意键终止服务！");
            Console.ReadKey();

            logServer.Stop();

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
            session.Send("哈哈");
        }
    }
}
