using Common;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rabbitmq.Core
{
    /// <summary>
    /// 消息消费者
    /// </summary>
    public static class MessageConsumer
    {
        private static ConnectionFactory _ConnectionFactory;
        private static IModel _Channel;

        /// <summary>
        /// 消息接收事件
        /// </summary>
        public static event Action<object, string, ulong> MessageReceivedEvent;

        private static ConnectionFactory ConnectionFactory
        {
            get
            {
                if (_ConnectionFactory == null)
                {
                    _ConnectionFactory=new ConnectionFactory()
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
                var channel = connection.CreateModel();
                if (channel == null)
                    throw new Exception("请先开启队列管道");

                //声明交换机
                channel.ExchangeDeclare(queueName, "direct", true, false, null);
                //声明队列
                channel.QueueDeclare(queueName, true, false, false, null);
                //声明队列绑定
                channel.QueueBind(queueName, queueName, $"Log/{queueName}", null);
            }
            return _Channel;
        }

        /// <summary>
        /// 开启消息的订阅
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="queueName"></param>
        public static void StartGet<T>(string queueName)
            where T : class
        {
            if (string.IsNullOrEmpty(queueName))
                throw new Exception("队列名称不能为空！");
            var channel = GetChannel(queueName);
            try
            {
                var consumer = new EventingBasicConsumer(channel);
                consumer.Received += new EventHandler<BasicDeliverEventArgs>((obj, e) =>
                {
                    Consumer_Received<T>(obj, e, queueName);
                });
                channel.BasicConsume(queueName, false, consumer);
            }
            catch (Exception ex)
            {
                Logger.Error($"从队列中获取信息失败:{ex} 队列名称:{queueName}");
            }
        }

        /// <summary>
        /// 发送接收消息状态
        /// </summary>
        public static void SendReceivedResult(string queueName, ulong msgId, bool isSucceed = true)
        {
            if (string.IsNullOrEmpty(queueName))
                throw new Exception("队列管道名称不能为空！");
            var channel = GetChannel(queueName);

            //确认已经接收到消息
            if (isSucceed)
                channel.BasicAck(msgId, false);
            else
                channel.BasicReject(msgId, true);
        }

        private static void Consumer_Received<T>(object sender, BasicDeliverEventArgs e, string queueName)
            where T : class
        {
            try
            {
                var body = e.Body;
                var msg = Encoding.UTF8.GetString(body);
                var obj = msg.ToObject<T>();
                if (obj != null)
                    MessageReceivedEvent?.Invoke(obj, queueName, e.DeliveryTag);
            }
            catch (Exception ex)
            {
                Logger.Error($"队列消息读取失败:{ex}");
            }
        }

    }
}
