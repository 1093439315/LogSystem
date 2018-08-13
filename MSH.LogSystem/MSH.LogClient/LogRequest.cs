using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSH.LogClient
{
    public class LogRequest
    {
        public string AppId { get; set; }
        /// <summary>
        /// 请求Id
        /// </summary>
        public string RequestId { get; set; }
        /// <summary>
        /// 日志内容
        /// </summary>
        public object Content { get; set; }
        /// <summary>
        /// 堆栈信息
        /// </summary>
        public string TraceInfo { get; set; }
        /// <summary>
        /// 业务位置
        /// </summary>
        public string BusinessPosition { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreatTime { get; set; }
    }
}
