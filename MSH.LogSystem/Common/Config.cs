using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace Common
{
    public static class Config
    {
        /// <summary>
        /// 消息队列Host
        /// </summary>
        public static string RabbitMqHost
        {
            get
            {
                var value = ConfigurationManager.AppSettings[$"{nameof(RabbitMqHost)}"];
                if (string.IsNullOrEmpty(value))
                    throw new Exception($"请在配置文件中配置{nameof(RabbitMqHost)}");
                return value;
            }
        }

        /// <summary>
        /// 消息队列用户名
        /// </summary>
        public static string RabbitMqUserName
        {
            get
            {
                var value = ConfigurationManager.AppSettings[$"{nameof(RabbitMqUserName)}"];
                if (string.IsNullOrEmpty(value))
                    throw new Exception($"请在配置文件中配置{nameof(RabbitMqUserName)}");
                return value;
            }
        }

        /// <summary>
        /// 消息队列密码
        /// </summary>
        public static string RabbitMqPassword
        {
            get
            {
                var value = ConfigurationManager.AppSettings[$"{nameof(RabbitMqPassword)}"];
                if (string.IsNullOrEmpty(value))
                    throw new Exception($"请在配置文件中配置{nameof(RabbitMqPassword)}");
                return value;
            }
        }

        /// <summary>
        /// 队列管道名称
        /// </summary>
        public static string ChannelName
        {
            get
            {
                var value = ConfigurationManager.AppSettings[$"{nameof(ChannelName)}"];
                if (string.IsNullOrEmpty(value))
                    throw new Exception($"请在配置文件中配置{nameof(ChannelName)}");
                return value;
            }
        }

        /// <summary>
        /// 消息队列名称
        /// </summary>
        public static string QueueName
        {
            get
            {
                var value = ConfigurationManager.AppSettings[$"{nameof(QueueName)}"];
                if (string.IsNullOrEmpty(value))
                    throw new Exception($"请在配置文件中配置{nameof(QueueName)}");
                return value;
            }
        }

        /// <summary>
        /// Info日志消息队列名称
        /// </summary>
        public static string InfoQueueName
        {
            get
            {
                var value = ConfigurationManager.AppSettings[$"{nameof(InfoQueueName)}"];
                if (string.IsNullOrEmpty(value))
                    throw new Exception($"请在配置文件中配置{nameof(InfoQueueName)}");
                return value;
            }
        }

        /// <summary>
        /// Warn日志消息队列名称
        /// </summary>
        public static string WarnQueueName
        {
            get
            {
                var value = ConfigurationManager.AppSettings[$"{nameof(WarnQueueName)}"];
                if (string.IsNullOrEmpty(value))
                    throw new Exception($"请在配置文件中配置{nameof(WarnQueueName)}");
                return value;
            }
        }

        /// <summary>
        /// Error日志消息队列名称
        /// </summary>
        public static string ErrorQueueName
        {
            get
            {
                var value = ConfigurationManager.AppSettings[$"{nameof(ErrorQueueName)}"];
                if (string.IsNullOrEmpty(value))
                    throw new Exception($"请在配置文件中配置{nameof(ErrorQueueName)}");
                return value;
            }
        }

        /// <summary>
        /// Debug日志消息队列名称
        /// </summary>
        public static string DebugQueueName
        {
            get
            {
                var value = ConfigurationManager.AppSettings[$"{nameof(DebugQueueName)}"];
                if (string.IsNullOrEmpty(value))
                    throw new Exception($"请在配置文件中配置{nameof(DebugQueueName)}");
                return value;
            }
        }
    }
}
