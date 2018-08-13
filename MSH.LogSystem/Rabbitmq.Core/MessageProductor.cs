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
    /// 消息生产者
    /// </summary>
    public static class MessageProductor
    {
        private static ConnectionFactory _ConnectionFactory;
        private static IModel _Channel;

        private static ConnectionFactory ConnectionFactory
        {
            get
            {
                if (_ConnectionFactory == null)
                {
                    _ConnectionFactory = new ConnectionFactory()
                    {
                        AutomaticRecoveryEnabled = true,
                        HostName = Config.RabbitMqHost,
                        UserName = Config.RabbitMqUserName,
                        Password = Config.RabbitMqPassword
                    };
                }
                return _ConnectionFactory;
            }
        }

        private static IModel GetChannel(string queueName)
        {
            if (_Channel == null)
            {
                var connection = ConnectionFactory.CreateConnection();
                _Channel = connection.CreateModel();
                if (_Channel == null)
                    throw new Exception("请先开启队列管道");

                //声明交换机
                _Channel.ExchangeDeclare(queueName, "direct", true, false, null);
                //声明队列
                _Channel.QueueDeclare(queueName, true, false, false, null);
                //声明队列绑定
                _Channel.QueueBind(queueName, queueName, $"Log/{queueName}", null);
            }
            return _Channel;
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
            if (string.IsNullOrEmpty(queueName))
                throw new Exception("队列名称不能为空！");
            var channel = GetChannel(queueName);
            var msgStr = obj.ToJson();
            try
            {
                var body = Encoding.UTF8.GetBytes(msgStr);
                channel.BasicPublish(queueName, $"Log/{queueName}", null, body);
            }
            catch (Exception ex)
            {
                Logger.Error($"消息发送到队列管道失败:{ex} 消息体:{obj.ToJson()} 队列名称:{queueName}");
            }
        }
    }
}
