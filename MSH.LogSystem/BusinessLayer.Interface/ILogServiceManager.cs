using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Interface
{
    public interface ILogServiceManager : IDependency
    {
        /// <summary>
        /// 发送Info日志
        /// </summary>
        void SendInfoLog(LogRequest request);

        /// <summary>
        /// 发送Error日志
        /// </summary>
        void SendErrorLog(LogRequest request);
    }
}