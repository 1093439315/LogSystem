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
    public static class RabbitMqMessageManage
    {
        /// <summary>
        /// 往队列管道发送消息
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        public static void Send<T>(this T obj, string queueName, string channelName = null)
            where T : class
        {
            if (obj == null) return;
            if (string.IsNullOrEmpty(queueName))
                throw new Exception("队列管道名称不能为空！");

            var channel = RabbitMqChannelManage.GetChannel(channelName);
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

        public static void Get<T>(string queueName, string channelName = null)
            where T : class
        {
            if (string.IsNullOrEmpty(queueName))
                throw new Exception("队列管道名称不能为空！");
            var channel = RabbitMqChannelManage.GetChannel(channelName);
            if (channel == null)
                throw new Exception("请先开启队列管道");
            
            try
            {
            }
            catch(Exception ex)
            {
                Logger.Error($"从队列中获取信息失败:{ex} 队列名称:{queueName}");
            }
        }
    }
}
