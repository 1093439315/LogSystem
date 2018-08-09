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
        /// 业务位置
        /// </summary>
        public string BusinessPosition { get; set; }
        /// <summary>
        /// 日志本体
        /// </summary>
        public object Message { get; set; }

        public LogData(string businessPosition, object data)
        {
            this.BusinessPosition = businessPosition;
            this.Message = data;
        }
    }
}
