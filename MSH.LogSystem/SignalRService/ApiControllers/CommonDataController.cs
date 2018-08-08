using Common;
using Configuration;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApiService.ApiControllers
{
    /// <summary>
    /// 公共数据服务
    /// </summary>
    public class CommonDataController : ManagerController
    {
        /// <summary>
        /// 获取所有日志级别
        /// </summary>
        /// <returns></returns>
        public AjaxReturnInfo QueryLogLevels()
        {
            var data = EnumExtension.GetAttributeInfo<LogLevel, NoteAttribute>("Note");
            return new AjaxReturnInfo()
            {
                Data = data,
            };
        }
    }
}
