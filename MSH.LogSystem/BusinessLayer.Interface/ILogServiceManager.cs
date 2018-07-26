using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Interface
{
    public interface ILogServiceManager : IDependency
    {
        /// <summary>
        /// 发送Info日志
        /// </summary>
        void SendInfoLog(LogRequest request);

        /// <summary>
        /// 发送Error日志
        /// </summary>
        void SendErrorLog(LogRequest request);

        /// <summary>
        /// 发送Warn日志
        /// </summary>
        void SendWarnLog(LogRequest request);

        /// <summary>
        /// 发送Debug日志
        /// </summary>
        void SendDebugLog(LogRequest request);

        /// <summary>
        /// 从消息队列中获取日志请求
        /// </summary>
        /// <param name="queueName">队列名称</param>
        /// <returns></returns>
        LogRequest GetLog(string queueName);
    }
}