﻿using DTO;
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
    public interface IInfoLogManager : IDependency
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

        /// <summary>
        /// 查询日志(可分页)
        /// </summary>
        /// <param name="logQuery">查询条件</param>
        /// <returns>日志信息</returns>
        List<LogInfo> QueryLogRequest(LogQuery logQuery);
    }
}