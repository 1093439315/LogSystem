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
    /// 消息队列管道
    /// </summary>
    public static class RabbitMqMessageManage
    {
        public static event Action<object> MessageReceivedEvent;

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
                throw new Exception("队列管道名称不能为空！");

            var channel = RabbitMqChannelManage.GetChannel(queueName);
            if (channel == null)
                throw new Exception("请先开启队列管道");

            var msgStr = obj.ToJson();
            try
            {
                var body = Encoding.UTF8.GetBytes(msgStr);
                channel.BasicPublish("", queueName, null, body);
            }
            catch (Exception ex)
            {
                Logger.Error($"消息发送到队列管道失败:{ex} 消息体:{obj.ToJson()} 队列名称:{queueName}");
            }
        }

        public static T Get<T>(string queueName)
            where T : class
        {
            if (string.IsNullOrEmpty(queueName))
                throw new Exception("队列管道名称不能为空！");
            var channel = RabbitMqChannelManage.GetChannel(queueName);
            if (channel == null)
                throw new Exception("请先开启队列管道");

            try
            {
                var consumer = new EventingBasicConsumer(channel);
                BasicGetResult result = channel.BasicGet(queueName, false);
                if (result == null) return null;
                byte[] body = result.Body;
                var msg = Encoding.UTF8.GetString(body);
                return msg.ToObject<T>();
            }
            catch (Exception ex)
            {
                Logger.Error($"从队列中获取信息失败:{ex} 队列名称:{queueName}");
                return null;
            }
        }

        /// <summary>
        /// 确认已经接收到消息
        /// </summary>
        public static void ReceivedSucceedCheck(string queueName, ulong msgId)
        {
            if (string.IsNullOrEmpty(queueName))
                throw new Exception("队列管道名称不能为空！");
            var channel = RabbitMqChannelManage.GetChannel(queueName);
            if (channel == null)
                throw new Exception("请先开启队列管道");

            //确认已经接收到消息
            channel.BasicAck(msgId, false);
        }

        public static void StartGet<T>(string queueName)
            where T : class
        {
            if (string.IsNullOrEmpty(queueName))
                throw new Exception("队列管道名称不能为空！");
            var channel = RabbitMqChannelManage.GetChannel(queueName);
            if (channel == null)
                throw new Exception("请先开启队列管道");

            try
            {
                var consumer = new EventingBasicConsumer(channel);
                consumer.Received += Consumer_Received<T>;
                channel.BasicConsume(queueName, false, consumer);
            }
            catch (Exception ex)
            {
                Logger.Error($"从队列中获取信息失败:{ex} 队列名称:{queueName}");
            }
        }

        private static void Consumer_Received<T>(object sender, BasicDeliverEventArgs e)
            where T : class
        {
            var body = e.Body;
            var msg = Encoding.UTF8.GetString(body);
            var obj = msg.ToObject<T>();
            if (obj != null)
                MessageReceivedEvent?.Invoke(obj);
        }
    }
}
