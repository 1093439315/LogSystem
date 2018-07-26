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
        private static Dictionary<string, IModel> Channels { get; set; } = new Dictionary<string, IModel>();

        public static IModel GetChannel(string channelName)
        {
            //队列管道名称为空时使用默认管道
            if (string.IsNullOrEmpty(channelName))
                channelName = Config.ChannelName;
            if (Channels == null)
                Channels = new Dictionary<string, IModel>();
            if (Channels.Keys.Contains(channelName))
                return Channels[channelName];

            var connection = RabbitMqConnectionManage.Connection;
            if (connection == null)
                throw new Exception("请先创建队列的连接！");

            var channel = connection.CreateModel();
            channel.QueueDeclare(channelName, true, false, false, null);
            Channels.Add(channelName, channel);
            return channel;
        }

        public static void Close()
        {
            if (Channels != null)
                Channels = null;
        }
    }
}
