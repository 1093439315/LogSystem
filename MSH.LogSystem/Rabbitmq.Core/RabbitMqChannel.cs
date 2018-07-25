using Common;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rabbitmq.Core
{
    /// <summary>
    /// 消息队列管道
    /// </summary>
    public static class RabbitMqChannel
    {
        private static ConnectionFactory ConnectionFactory { get; set; }
        
        private static IConnection Connection { get; set; }
        
        public static IModel Channel { get; private set; }

        public static bool RabbitMqChannelStart()
        {
            try
            {
                if (ConnectionFactory == null)
                {
                    ConnectionFactory = new ConnectionFactory();
                    ConnectionFactory.HostName = Config.RabbitMqHost;
                    ConnectionFactory.UserName = Config.RabbitMqUserName;
                    ConnectionFactory.Password = Config.RabbitMqPassword;
                }
                if (Connection == null)
                {
                    Connection = ConnectionFactory?.CreateConnection();
                }
                if (Channel == null)
                {
                    Channel = Connection?.CreateModel();
                }
            }
            catch (Exception ex)
            {
                Logger.Error($"消息队列管道初始化失败:{ex}");
                return false;
            }
            return true;
        }

        public static void RabbitMqChannelStop()
        {
            if (Channel != null)
            {
                Channel.Dispose();
                Channel = null;
            }
            if (Connection != null)
            {
                Connection.Dispose();
                Connection = null;
            }
            if (ConnectionFactory != null)
            {
                ConnectionFactory = null;
            }
        }

        /// <summary>
        /// 往队列管道发送消息
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        public static void Send<T>(this T obj, string queueName)
            where T : class
        {
            if (obj == null) return;
            if (Channel == null)
                throw new Exception("请先开启队列管道");
            if (string.IsNullOrEmpty(queueName))
                throw new Exception("队列管道名称不能为空！");
            var msgStr = obj.ToJson();
            try
            {
                //第二个参数Ture 表示队列消息持久化
                Channel.QueueDeclare(queueName, true, false, false, null);
                var body = Encoding.UTF8.GetBytes(msgStr);
                Channel.BasicPublish("", queueName, null, body);
            }
            catch (Exception ex)
            {
                Logger.Error($"消息发送到队列管道失败:{ex} 消息体:{obj.ToJson()} 管道名称:{queueName}");
            }
        }
    }
}
