using BusinessLayer.Interface;
using Common;
using Configuration;
using DTO;
using MongoDbAccess;
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
        private InfoLogAccess _InfoLogAccess = new InfoLogAccess();
        public event Action<LogRequest> MessageReceivedEvent;

        public string AppId { get; set; }

        public LogMQServiceManager()
        {
            MessageConsumer.MessageReceivedEvent += MessageConsumer_MessageReceivedEvent;
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
            //var queueName = level.ToString();
            //var obj = MessageConsumer.Get<LogRequest>(queueName);
            //return obj;
            return null;
        }

        public void StartGetMsg(LogLevel level)
        {
            var queueName = level.ToString();
            MessageConsumer.StartGet<LogRequest>(queueName);
        }

        /// <summary>
        /// 处理发送来的日志
        /// </summary>
        /// <param name="obj"></param>
        private void MessageConsumer_MessageReceivedEvent(object obj, string queueName, ulong msgId)
        {
            var log = obj as LogRequest;
            if (log == null)
            {
                //让消息重新回到队列
                MessageConsumer.SendReceivedResult(queueName, msgId, false);
                Logger.Error($"队列消息反序列化失败:{obj.ToJson()}");
                return;
            }
            //将日志写入MogoDb
            Logger.Info($"从队列中读取了消息:{obj.ToJson()}");
            var res = SaveLog(log);
            if (res)
                MessageConsumer.SendReceivedResult(queueName, msgId, true);
            else
                MessageConsumer.SendReceivedResult(queueName, msgId, false);
        }

        private bool SaveLog(LogRequest logRequest)
        {
            try
            {
                _InfoLogAccess.AddInfoLog(logRequest);
                return true;
            }
            catch (Exception ex)
            {
                Logger.Error($"{nameof(logRequest.AppId)}:{logRequest.AppId} 保存日志发生错误:{ex}  日志内容:{logRequest.ToJson()}");
                return false;
            }
        }

        #endregion
    } 
}
