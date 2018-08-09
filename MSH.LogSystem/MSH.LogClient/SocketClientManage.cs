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
    internal class SocketClientManage
    {
        static EasyClient client;
        static Task ReadLogTask;
        static Task WatchSocketTask;
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

        /// <summary>
        /// 创建一个新的Socket连接
        /// </summary>
        /// <param name="ip"></param>
        /// <param name="port"></param>
        public static void Start(string ip, int port)
        {
            //创建socket
            if (client == null)
                client = CreatClient(ip, port);

            //连接socket
            Connect(ip, port);

            //创建读取队列任务
            CreatReadTask();

            //创建Socket连接监控任务
            CreatSocketWatchTask(ip, port);
        }

        #region 客户端事件

        private static void Client_Error(object sender, ErrorEventArgs e)
        {
            Console.WriteLine($"客户端发生错误：{e.Exception}");
            AutoEvent.Reset();
        }

        private static void Client_Connected(object sender, EventArgs e)
        {
            Console.WriteLine("客户端连接");
            //继续读取任务
            AutoEvent.Set();
        }

        private static void Client_Closed(object sender, EventArgs e)
        {
            Console.WriteLine("客户端关闭");
            //暂停读取日志
            AutoEvent.Reset();
        }

        #endregion

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
        
        private static EasyClient CreatClient(string ip, int port)
        {
            var client = new EasyClient();
            client.Error += Client_Error;
            client.Connected += Client_Connected;
            client.Closed += Client_Closed;
            client.Initialize(new BeiginEndReceiveFilter(), (request) =>
            {
                Console.WriteLine(request.Key);
            });
            return client;
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
                    while (true)
                    {
                        //连接成功了才开始读取
                        AutoEvent.WaitOne();
                        Console.WriteLine("开始读取！");
                        var item = MSHLogger.LoggingEvents.Take();
                        if (item == null) continue;
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

        /// <summary>
        /// 创建Socket监控任务
        /// </summary>
        private static void CreatSocketWatchTask(string ip, int port)
        {
            if (WatchSocketTask == null)
            {
                Task.Run(() =>
                {
                    while (true)
                    {
                        if (IsConnected) continue;

                        Console.WriteLine("尝试重连！");
                        Connect(ip, port);

                        Thread.Sleep(3000);
                    }
                });
            }

            return;

            if (WatchSocketTask == null)
            {
                WatchSocketTask = Task.Factory.StartNew(() =>
                {
                    while (true)
                    {
                        if (IsConnected) continue;

                        Console.WriteLine("尝试重连！");
                        Connect(ip, port);

                        Thread.Sleep(3000);
                    }
                });
            }
            else
            {
                if (WatchSocketTask.Status != TaskStatus.Running)
                    WatchSocketTask.Start();
            }
        }

        private static void Connect(string ip, int port)
        {
            try
            {
                if (!IsConnected)
                    client?.ConnectAsync(new IPEndPoint(IPAddress.Parse(ip), port));
            }
            catch (Exception ex)
            {
                Logger.Error($"连接Socket服务失败:{ex}");
            }
        }
    }
}
