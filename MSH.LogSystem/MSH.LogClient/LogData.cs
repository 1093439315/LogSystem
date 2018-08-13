using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSH.LogClient
{
    internal class LogData
    {
        /// <summary>
        /// 请求Id
        /// </summary>
        public string RequestId { get; set; }
        /// <summary>
        /// 业务位置
        /// </summary>
        public string BusinessPosition { get; set; }
        /// <summary>
        /// 日志本体
        /// </summary>
        public object Message { get; set; }
        /// <summary>
        /// 堆栈信息
        /// </summary>
        public string TraceInfo { get; set; }

        public LogData(string businessPosition, object data, string traceInfo = null)
        {
            this.BusinessPosition = businessPosition;
            this.Message = data;
            this.TraceInfo = traceInfo;
        }

        public LogData(string requestId , string businessPosition, object data, string traceInfo = null)
        {
            this.BusinessPosition = businessPosition;
            this.Message = data;
            this.TraceInfo = traceInfo;
            this.RequestId = requestId;
        }
    }
}
