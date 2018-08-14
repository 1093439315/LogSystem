using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Interface
{
    /// <summary>
    /// 日志管理-error
    /// </summary>
    public interface IErrorLogManager : IDependency
    {
        /// <summary>
        /// 删除日志
        /// </summary>
        void DeleteLog(long id);

        /// <summary>
        /// 查询日志(可分页)
        /// </summary>
        /// <param name="logQuery">查询条件</param>
        /// <returns>日志信息</returns>
        List<LogInfo> QueryLogInfo(LogQuery logQuery);
    }
}
