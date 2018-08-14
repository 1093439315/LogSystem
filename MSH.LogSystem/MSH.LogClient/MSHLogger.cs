using log4net.Core;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
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
        /// <summary>
        /// 请求Id
        /// </summary>
        internal string RequestId { get; set; }
        private static log4net.ILog Log { get; set; }

        /// <summary>
        /// 实例模式
        /// </summary>
        /// <param name="businessPosition">业务位置</param>
        /// <returns></returns>
        public static MSHLogger Instance(params string[] businessPosition)
        {
            var _MSHLogger = new MSHLogger();
            if (businessPosition != null && businessPosition.Length >= 1)
                _MSHLogger.BusinessPosition = string.Join(".", businessPosition);
            return _MSHLogger;
        }

        /// <summary>
        /// 实例模式直接通过RequestId记录日志(无业务位置)
        /// </summary>
        /// <returns></returns>
        public static MSHLogger Request(string requestId)
        {
            var _MSHLogger = new MSHLogger();
            if (!string.IsNullOrEmpty(requestId))
                _MSHLogger.RequestId = requestId;
            return _MSHLogger;
        }

        /// <summary>
        /// 客户端日志队列
        /// </summary>
        internal static BlockingCollection<LoggingEvent> LoggingEvents { get; set; } = new BlockingCollection<LoggingEvent>();

        static MSHLogger()
        {
        }

        #region Info日志

        /// <summary>
        /// 默认业务记录Info日志
        /// </summary>
        /// <param name="message"></param>
        public static void DefaultInfo(object message)
        {
            var trace = new StackTrace(true);
            var frameMethod = trace.GetFrame(1).GetMethod();
            Log = log4net.LogManager.GetLogger($"{frameMethod.ReflectedType}.{frameMethod.Name}");
            Log.Info(new LogData(null, message, GetTraceInfo(trace.GetFrames())));
        }

        /// <summary>
        /// 指定业务记录Info日志
        /// </summary>
        /// <param name="message"></param>
        public void Info(object message)
        {
            var trace = new StackTrace(true);
            var frameMethod = trace.GetFrame(1).GetMethod();
            Log = log4net.LogManager.GetLogger($"{frameMethod.ReflectedType}.{frameMethod.Name}");
            Log.Info(new LogData(this.RequestId, this.BusinessPosition, message, GetTraceInfo(trace.GetFrames())));
        }

        #endregion

        #region Error日志

        /// <summary>
        /// 默认业务记录Error日志
        /// </summary>
        /// <param name="message"></param>
        public static void DefaultError(object message)
        {
            var trace = new StackTrace(true);
            var frameMethod = trace.GetFrame(1).GetMethod();
            Log = log4net.LogManager.GetLogger($"{frameMethod.ReflectedType}.{frameMethod.Name}");
            Log.Error(new LogData(null, message, GetTraceInfo(trace.GetFrames())));
        }

        /// <summary>
        /// 指定业务记录Error日志
        /// </summary>
        /// <param name="message"></param>
        public void Error(object message)
        {
            var trace = new StackTrace(true);
            var frameMethod = trace.GetFrame(1).GetMethod();
            Log = log4net.LogManager.GetLogger($"{frameMethod.ReflectedType}.{frameMethod.Name}");
            Log.Error(new LogData(this.RequestId, this.BusinessPosition, message, GetTraceInfo(trace.GetFrames())));
        }

        #endregion

        private static string GetTraceInfo(StackFrame[] frames)
        {
            if (frames == null || frames.Length == 0) return null;
            List<string> traceInfos = new List<string>();
            foreach (var item in frames)
                traceInfos.Add($"在类:{item.GetMethod().DeclaringType} 方法:{item.GetMethod()} 行:{item.GetFileLineNumber()}");
            return string.Join(";\r\n", traceInfos);
        }
    }
}
