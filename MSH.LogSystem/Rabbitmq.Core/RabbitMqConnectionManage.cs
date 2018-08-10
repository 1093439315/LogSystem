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
        private static List<IConnection> AllConnections { get; set; } = new List<IConnection>();
        private static IConnection IConnection { get; set; }

        public static IConnection CreatConnection()
        {
            if (ConnectionFactory == null)
            {
                ConnectionFactory = new ConnectionFactory();
                ConnectionFactory.AutomaticRecoveryEnabled = true;
                ConnectionFactory.HostName = Config.RabbitMqHost;
                ConnectionFactory.UserName = Config.RabbitMqUserName;
                ConnectionFactory.Password = Config.RabbitMqPassword;
            }
            if (IConnection == null || !IConnection.IsOpen)
                IConnection = ConnectionFactory?.CreateConnection();
            return IConnection;
            //var connection= ConnectionFactory?.CreateConnection();
            //AllConnections.Add(connection);
            //return connection;
        }

        public static IConnection CreatConnection(string userName, string password)
        {
            if (ConnectionFactory == null)
            {
                ConnectionFactory = new ConnectionFactory();
                ConnectionFactory.HostName = Config.RabbitMqHost;
                ConnectionFactory.UserName = userName;
                ConnectionFactory.Password = password;
            }
            if (IConnection == null || !IConnection.IsOpen)
                IConnection = ConnectionFactory?.CreateConnection();
            return IConnection;
            //var connection = ConnectionFactory?.CreateConnection();
            //AllConnections.Add(connection);
            //return connection;
        }

        public static void Close()
        {
            if (ConnectionFactory != null)
                ConnectionFactory = null;
            IConnection?.Close();
            foreach (var Connection in AllConnections)
            {
                if (Connection != null)
                {
                    Connection.Close();
                    Connection.Dispose();
                }
            }
        }
    }
}
