using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class BaseLog : BaseEntity
    {
        /// <summary>
        /// 日志级别
        /// </summary>
        public short LogLevel { get; set; }
        /// <summary>
        /// 生成时间
        /// </summary>
        public DateTime CreationTime { get; set; }
        /// <summary>
        /// 日志内容
        /// </summary>
        public string Content { get; set; }
        /// <summary>
        /// 堆栈信息
        /// </summary>
        public string TraceInfo { get; set; }
        /// <summary>
        /// 业务Id
        /// </summary>
        public ObjectId BusinessId { get; set; }
    }
}
