using BusinessLayer.Interface;
using Common;
using Configuration;
using DTO;
using Rabbitmq.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class LogMQServiceManager : ILogMQServiceManager
    {
        public event Action<LogRequest> MessageReceivedEvent;

        public LogMQServiceManager()
        {
            RabbitMqMessageManage.MessageReceivedEvent += RabbitMqMessageManage_MessageReceivedEvent;
        }

        #region 向队列插入日志

        public void SendErrorLog(LogRequest request)
        {
            request.Send(LogLevel.Error.ToString());
        }

        public void SendInfoLog(LogRequest request)
        {
            request.Send(LogLevel.Info.ToString());
        }
        
        public void SendWarnLog(LogRequest request)
        {
            request.Send(LogLevel.Warn.ToString());
        }

        public void SendDebugLog(LogRequest request)
        {
            request.Send(LogLevel.Debug.ToString());
        }

        #endregion

        #region 从队列中接收消息

        public LogRequest GetLog(LogLevel level)
        {
            var queueName = level.ToString();
            var obj = RabbitMqMessageManage.Get<LogRequest>(queueName);
            return obj;
        }

        public void StartGetMsg(LogLevel level)
        {
            var queueName = level.ToString();
            RabbitMqMessageManage.StartGet<LogRequest>(queueName);
        }

        /// <summary>
        /// 处理发送来的日志
        /// </summary>
        /// <param name="obj"></param>
        private void RabbitMqMessageManage_MessageReceivedEvent(object obj, string queueName, ulong msgId)
        {
            var log = obj as LogRequest;
            if (log == null)
            {
                Logger.Info($"队列消息反序列化失败:{obj.ToJson()}");
                return;
            }
            //将日志写入MogoDb
            Console.WriteLine($"从队列中读取了消息:{obj.ToJson()}");
            //让消息重新回到队列
            RabbitMqMessageManage.SendReceivedResult(queueName, msgId, false);
        }

        #endregion
    }
}
