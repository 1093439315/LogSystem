using Common;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rabbitmq.Core
{
    internal class RabbitMqChannelManage
    {
        private static Dictionary<string, IModel> SaveChannels { get; set; } = new Dictionary<string, IModel>();
        private static Dictionary<string, IModel> ReadChannels { get; set; } = new Dictionary<string, IModel>();

        /// <summary>
        /// 获取插入Channel
        /// </summary>
        /// <param name="channelName"></param>
        /// <returns></returns>
        public static IModel GetSaveChannel(string channelName)
        {
            //队列管道名称为空时使用默认管道
            if (string.IsNullOrEmpty(channelName))
                channelName = Config.DefaultQueueName;
            if (SaveChannels == null)
                SaveChannels = new Dictionary<string, IModel>();
            if (SaveChannels.Keys.Contains(channelName))
                return SaveChannels[channelName];

            var connection = RabbitMqConnectionManage.CreatConnection();
            if (connection == null)
                throw new Exception("请先创建队列的连接！");

            var channel = connection.CreateModel();
            //声明交换机
            channel.ExchangeDeclare(channelName, "direct", true, false, null);
            //声明队列
            channel.QueueDeclare(channelName, true, false, false, null);
            //声明队列绑定
            channel.QueueBind(channelName, channelName, $"Log/{channelName}", null);
            SaveChannels.Add(channelName, channel);
            return channel;
        }

        /// <summary>
        /// 获取读取Channel
        /// </summary>
        /// <param name="channelName"></param>
        /// <returns></returns>
        public static IModel GetReadChannel(string channelName)
        {
            //队列管道名称为空时使用默认管道
            if (string.IsNullOrEmpty(channelName))
                channelName = Config.DefaultQueueName;
            if (ReadChannels == null)
                ReadChannels = new Dictionary<string, IModel>();
            if (ReadChannels.Keys.Contains(channelName))
                return ReadChannels[channelName];

            var connection = RabbitMqConnectionManage.CreatConnection();
            if (connection == null)
                throw new Exception("请先创建队列的连接！");
            
            var channel = connection.CreateModel();
            //声明交换机
            channel.ExchangeDeclare(channelName, "direct", true, false, null);
            //声明队列
            channel.QueueDeclare(channelName, true, false, false, null);
            //声明队列绑定
            channel.QueueBind(channelName, channelName, $"Log/{channelName}", null);
            ReadChannels.Add(channelName, channel);
            return channel;
        }

        public static void Close()
        {
            if (SaveChannels != null)
            {
                foreach (var item in SaveChannels)
                {
                    item.Value.Close();
                }
                SaveChannels = null;
            }

            if (ReadChannels != null)
            {
                foreach (var item in ReadChannels)
                {
                    item.Value.Close();
                }
                ReadChannels = null;
            }
        }
    }
}
