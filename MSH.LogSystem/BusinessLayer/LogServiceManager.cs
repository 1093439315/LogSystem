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
        #region 向队列插入日志

        public void SendErrorLog(LogRequest request)
        {
            request.Send(Config.ErrorQueueName);
        }

        public void SendInfoLog(LogRequest request)
        {
            request.Send(Config.InfoQueueName);
        }
        
        public void SendWarnLog(LogRequest request)
        {
            request.Send(Config.WarnQueueName);
        }

        public void SendDebugLog(LogRequest request)
        {
            request.Send(Config.DebugQueueName);
        }

        #endregion

        public LogRequest GetLog(string queueName)
        {
            return null;
        }
    }
}
