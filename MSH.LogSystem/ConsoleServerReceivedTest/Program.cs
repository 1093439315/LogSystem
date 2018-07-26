using BusinessLayer;
using BusinessLayer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Configuration;
using Rabbitmq.Core;

namespace ConsoleServerReceivedTest
{
    class Program
    {
        static void Main(string[] args)
        {
            RabbitMqServiceManage.Start();
            ILogServiceManager manager = new LogServiceManager();
            manager.StartGetMsg(LogLevel.Info);
            Console.ReadLine();
        }
    }
}
