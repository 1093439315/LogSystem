using log4net.Appender;
using log4net.Core;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSH.LogClient
{
    /// <summary>
    /// log4net自定义日志Appender
    /// </summary>
    public class MshLog4netSocketAppender : AppenderSkeleton
    {
        /// <summary>
        /// 日志服务器地址
        /// </summary>
        public string ServerHost { get; set; }
        /// <summary>
        /// 日志服务器端口
        /// </summary>
        public string ServerPort { get; set; }

        public string AppId { get; set; }
        public string Secrect { get; set; }

        protected override void Append(LoggingEvent loggingEvent)
        {
            SocketClientManage.Start(this.ServerHost, int.Parse(this.ServerPort));
            SetLogProperty(loggingEvent);
            MSHLogger.LoggingEvents.Add(loggingEvent);
            var obj = loggingEvent;
        }

        protected override void Append(LoggingEvent[] loggingEvents)
        {
            SocketClientManage.Start(this.ServerHost, int.Parse(this.ServerPort));
            loggingEvents.ToList().ForEach(a =>
            {
                SetLogProperty(a);
                MSHLogger.LoggingEvents.Add(a);
            });
            base.Append(loggingEvents);
        }

        protected void SetLogProperty(LoggingEvent loggingEvent)
        {
            loggingEvent.Properties[nameof(ServerHost)] = ServerHost;
            loggingEvent.Properties[nameof(ServerPort)] = ServerPort;
            loggingEvent.Properties[nameof(AppId)] = AppId;
            loggingEvent.Properties[nameof(Secrect)] = Secrect;
        }
    }
}
