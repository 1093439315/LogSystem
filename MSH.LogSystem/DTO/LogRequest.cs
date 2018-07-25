using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class LogRequest
    {
        /// <summary>
        /// 日志内容
        /// </summary>
        public object Content { get; set; }
        /// <summary>
        /// 堆栈信息
        /// </summary>
        public string TraceInfo { get; set; }
        /// <summary>
        /// 业务Id
        /// </summary>
        public string BusinessPosition { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreatTime { get; set; }
    }
}
