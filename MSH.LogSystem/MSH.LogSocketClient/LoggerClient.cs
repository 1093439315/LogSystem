using SuperSocket.ClientEngine;
using SuperSocket.ProtoBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace MSH.LogSocketClient
{
    public class LoggerClient
    {
        static EasyClient client = new EasyClient();

        public static void Connect()
        {
            //AsyncTcpSession
            string ip = "127.0.0.1";
            int port = 2012;
            client.Error += Client_Error;
            client.Connected += Client_Connected;
            client.Closed += Client_Closed;

            client.Initialize(new BeiginEndReceiveFilter(), (request) => 
            {
                Console.WriteLine(request.Key);
            });
            client.ConnectAsync(new IPEndPoint(IPAddress.Parse(ip), port)).Wait();
            Console.Read();

            client.Close();
        }

        private static void Client_Error(object sender, ErrorEventArgs e)
        {
            Console.WriteLine("客户端发生错误！");
        }

        private static void Client_Connected(object sender, EventArgs e)
        {
            Console.WriteLine("客户端连接");
            client.Send(Encoding.UTF8.GetBytes("!LOGIN kerry$"));
        }

        private static void Client_Closed(object sender, EventArgs e)
        {
            Console.WriteLine("客户端关闭");
        }
    }
}
