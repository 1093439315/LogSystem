using log4net.Appender;
using log4net.Core;
using System;
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
        public string RemoteAddress { get; set; }

        protected override void Append(LoggingEvent loggingEvent)
        {
            Console.WriteLine("日志啊");
            var obj = loggingEvent;
        }

        protected override void Append(LoggingEvent[] loggingEvents)
        {
            Console.WriteLine("日志啊");
            base.Append(loggingEvents);
        }
    }
}
