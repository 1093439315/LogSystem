using Common;
using Configuration;
using DTO;
using log4net.Core;
using SuperSocket.ClientEngine;
using SuperSocket.ProtoBase;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MSH.LogClient
{
    internal class LoggerSocketClient
    {
        static EasyClient client = new EasyClient();
        static Task ReadLogTask;
        private static AutoResetEvent AutoEvent = new AutoResetEvent(false);

        /// <summary>
        /// 是否连接
        /// </summary>
        public static bool IsConnected
        {
            get
            {
                if (client == null) return false;
                return client.IsConnected;
            }
        }

        static LoggerSocketClient()
        {
            client.Error += Client_Error;
            client.Connected += Client_Connected;
            client.Closed += Client_Closed;
            client.Initialize(new BeiginEndReceiveFilter(), (request) =>
            {
                Console.WriteLine(request.Key);
            });
        }

        public static void Connect(string ip, int port)
        {
            CreatReadTask();
            
            client.ConnectAsync(new IPEndPoint(IPAddress.Parse(ip), port)).Wait();
            
            client.Close();
        }

        private static void Client_Error(object sender, ErrorEventArgs e)
        {
            Console.WriteLine("客户端发生错误！");
        }

        private static void Client_Connected(object sender, EventArgs e)
        {
            Console.WriteLine("客户端连接");
            //继续读取任务
            AutoEvent.Reset();

            //连接完成启动读取Task

        }

        private static void Client_Closed(object sender, EventArgs e)
        {
            Console.WriteLine("客户端关闭");
            //暂停读取日志
            AutoEvent.Set();
        }

        public static void SendMessage()
        {
            var body = new LogRequest()
            {
                BusinessPosition = "订单.新建",
                Content = "测试日志内容而已",
                CreatTime = DateTime.Now,
                TraceInfo = "测试堆栈信息",
            };
            var pack = new StringPackageInfo(LogLevel.Info.ToString(), body.ToJson(), null);
            var msg = $"{Config.BeginMarkStr}{pack.ToJson()}{Config.EndMarkStr}";
            client.Send(Encoding.UTF8.GetBytes(msg));
        }

        /// <summary>
        /// 创建连接任务
        /// </summary>
        private static void CreatConnectTask()
        {

        }

        /// <summary>
        /// 创建读取任务
        /// </summary>
        private static void CreatReadTask()
        {
            if (ReadLogTask == null)
            {
                ReadLogTask = Task.Factory.StartNew(() =>
                {
                    while (!MSHLogger.LoggingEvents.IsCompleted)
                    {
                        AutoEvent.WaitOne();
                        var item = MSHLogger.LoggingEvents.Take();
                        //读取Ip和port


                        Console.WriteLine(item.ToJson());
                    }
                });
            }
            else
            {
                if (ReadLogTask.Status != TaskStatus.Running)
                    ReadLogTask.Start();
            }
        }
    }
}
