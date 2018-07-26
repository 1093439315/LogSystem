using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Interface
{
    /// <summary>
    /// 日志管理
    /// </summary>
    public interface ILogManager : IDependency
    {
        /// <summary>
        /// 添加日志
        /// </summary>
        /// <param name="logRequest"></param>
        void AddInfoLog(LogRequest logRequest);

        /// <summary>
        /// 删除日志
        /// </summary>
        void DeleteLog(long id);
    }
}
