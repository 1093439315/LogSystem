using BusinessLayer.Interface;
using Common;
using DTO;
using Rabbitmq.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class LogServiceManager : ILogServiceManager
    {
        public void SendErrorLog(LogRequest request)
        {
            request.Send(Config.QueueName);
        }

        public void SendInfoLog(LogRequest request)
        {
            request.Send(Config.QueueName);
        }
    }
}
