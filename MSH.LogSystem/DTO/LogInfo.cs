using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    /// <summary>
    /// 日志信息
    /// </summary>
    public class LogInfo
    {
        /// <summary>
        /// 来源平台
        /// </summary>
        public string Platform { get; set; }
        /// <summary>
        /// 业务位置
        /// </summary>
        public string BusinessPosition { get; set; }
        /// <summary>
        /// 日志内容
        /// </summary>
        public string Content { get; set; }
        /// <summary>
        /// 堆栈信息
        /// </summary>
        public string TraceInfo { get; set; }
        /// <summary>
        /// 请求Id
        /// </summary>
        public string RequestId { get; set; }
        /// <summary>
        /// 日志生成时间
        /// </summary>
        public DateTime CreationTime { get; set; }
    }
}
