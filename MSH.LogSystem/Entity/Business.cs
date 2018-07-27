using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    /// <summary>
    /// 业务
    /// </summary>
    public class Business : BaseEntity
    {
        /// <summary>
        /// 平台Id
        /// </summary>
        public ObjectId PlatformId { get; set; }
        
        /// <summary>
        /// 业务链路 例如：收银服务-订单-新建
        /// </summary>
        public List<string> BusinessLink { get; set; }
    }
}
