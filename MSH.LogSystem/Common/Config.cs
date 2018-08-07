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
        /// 默认消息队列名称
        /// </summary>
        public static string DefaultQueueName
        {
            get
            {
                var value = ConfigurationManager.AppSettings[$"{nameof(DefaultQueueName)}"];
                if (string.IsNullOrEmpty(value))
                    throw new Exception($"请在配置文件中配置{nameof(DefaultQueueName)}");
                return value;
            }
        }

        /// <summary>
        /// MongoDb连接字符串
        /// </summary>
        public static string MongoDbConnStr
        {
            get
            {
                var value = ConfigurationManager.ConnectionStrings[$"{nameof(MongoDbConnStr)}"]?.ConnectionString;
                if (string.IsNullOrEmpty(value))
                    throw new Exception($"请在连接字符串配置文件中配置{nameof(MongoDbConnStr)}");
                return value;
            }
        }

        /// <summary>
        /// 系统Secrect 非常重要
        /// </summary>
        public static string SystemSecrect
        {
            get
            {
                var value = ConfigurationManager.AppSettings[$"{nameof(SystemSecrect)}"];
                if (string.IsNullOrEmpty(value))
                    throw new Exception($"请在配置文件中配置{nameof(SystemSecrect)}");
                return value;
            }
        }

        /// <summary>
        /// Token过期时间 非常重要
        /// </summary>
        public static string TokenExpireMinutes
        {
            get
            {
                var value = ConfigurationManager.AppSettings[$"{nameof(TokenExpireMinutes)}"];
                if (string.IsNullOrEmpty(value))
                    throw new Exception($"请在配置文件中配置{nameof(TokenExpireMinutes)}");
                return value;
            }
        }

        /// <summary>
        /// Socket监听端口
        /// </summary>
        public static int SocketPort
        {
            get
            {
                var value = ConfigurationManager.AppSettings[$"{nameof(SocketPort)}"];
                if (string.IsNullOrEmpty(value))
                    throw new Exception($"请在配置文件中配置{nameof(SocketPort)}");
                if (int.TryParse(value, out int res))
                    return res;
                throw new Exception($"{nameof(SocketPort)}必须为整数");
            }
        }
    }
}
