using Common;
using Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class LogQuery
    {
        public Pagination Pagination { get; set; } = new Pagination();

        /// <summary>
        /// 日志等级
        /// </summary>
        public LogLevel? LogLevel { get; set; }
        /// <summary>
        /// 日志内容模糊查询
        /// </summary>
        public string Content { get; set; }
        /// <summary>
        /// 创建时间查询开始范围
        /// </summary>
        public DateTime? CreatTimeFrom { get; set; }
        /// <summary>
        /// 创建时间查询结束范围
        /// </summary>
        public DateTime? CreatTmeTo { get; set; }
        /// <summary>
        /// 日志来源平台
        /// </summary>
        public string PlatformId { get; set; }
        /// <summary>
        /// 日志业务位置
        /// </summary>
        public string BusinessPosition { get; set; }
        /// <summary>
        /// 日志堆栈信息
        /// </summary>
        public string TraceInfo { get; set; }
    }
}
