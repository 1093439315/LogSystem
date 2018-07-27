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
        /// <summary>
        /// 业务位置
        /// </summary>
        public string BusinessPosition { get; set; }
        /// <summary>
        /// 平台Id
        /// </summary>
        public ObjectId PlatformId { get; set; }
    }
}
