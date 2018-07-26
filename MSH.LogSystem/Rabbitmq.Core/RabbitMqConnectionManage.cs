using Common;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rabbitmq.Core
{
    internal class RabbitMqConnectionManage
    {
        private static ConnectionFactory ConnectionFactory { get; set; }

        public static IConnection Connection { get; private set; }

        public static void CreatConnection()
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
        }

        public static void CreatConnection(string userName,string password)
        {
            if (ConnectionFactory == null)
            {
                ConnectionFactory = new ConnectionFactory();
                ConnectionFactory.HostName = Config.RabbitMqHost;
                ConnectionFactory.UserName = userName;
                ConnectionFactory.Password = password;
            }
            if (Connection == null)
            {
                Connection = ConnectionFactory?.CreateConnection();
            }
        }

        public static void Close()
        {
            if (ConnectionFactory != null)
                ConnectionFactory = null;
            if (Connection != null)
            {
                Connection.Close();
                Connection.Dispose();
                Connection = null;
            }
        }
    }
}
