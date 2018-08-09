using log4net.Core;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MSH.LogClient
{
    public class MSHLogger
    {
        /// <summary>
        /// 业务位置
        /// </summary>
        private string BusinessPosition { get; set; }
        private static log4net.ILog Log { get; set; }

        //实例模式
        public static MSHLogger Instance(params string[] businessPosition)
        {
            var _MSHLogger = new MSHLogger();
            if (businessPosition != null && businessPosition.Length >= 1)
                _MSHLogger.BusinessPosition = string.Join(".", businessPosition);
            return _MSHLogger;
        }

        /// <summary>
        /// 客户端日志队列
        /// </summary>
        internal static BlockingCollection<LoggingEvent> LoggingEvents { get; set; } = new BlockingCollection<LoggingEvent>();

        #region Info日志

        /// <summary>
        /// 默认业务记录Info日志
        /// </summary>
        /// <param name="message"></param>
        public static void DefaultInfo(object message)
        {
            Log = log4net.LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
            Log.Info(message);
        }

        /// <summary>
        /// 指定业务记录Info日志
        /// </summary>
        /// <param name="message"></param>
        public void Info(object message)
        {
            Log = log4net.LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
            Log.Info(new LogData(this.BusinessPosition, message));
        }

        #endregion

    }
}
