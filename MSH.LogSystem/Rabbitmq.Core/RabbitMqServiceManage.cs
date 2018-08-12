using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rabbitmq.Core
{
    public static class RabbitMqServiceManage
    {
        public static bool Start()
        {
            try
            {
                //创建连接
                RabbitMqConnectionManage.CreatConnection();
                return true;
            }
            catch (Exception ex)
            {
                Logger.Error($"开启队列服务失败:{ex}");
                return false;
            }
        }

        public static void Stop()
        {
            RabbitMqChannelManage.Close();
            RabbitMqConnectionManage.Close();
        }
        
    }
}
