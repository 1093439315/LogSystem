﻿using DTO;
using Flurl.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleClientTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Task.Run(() =>
            {
                for (int i = 1; i <= 2000; i++)
                {
                    Send(i);
                }
            });
            Console.ReadLine();
        }

        private static void Send(int i)
        {
            Console.WriteLine($"执行发送请求:{i}");
            //var url = "http://192.168.1.61/MSH.LogSystem/api/LogService/Info";
            var url = "http://log.jiewit.com/api/LogService/Info";
            url.PostJsonAsync(new LogRequest()
            {
                BusinessPosition = "订单.删除",
                Content = "这是一个测试删除日志内容",
                CreatTime = DateTime.Now,
                TraceInfo = "这是测试堆栈信息",
            }).Wait();
        }
    }
}
