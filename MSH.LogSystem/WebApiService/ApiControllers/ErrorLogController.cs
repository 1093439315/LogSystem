﻿using BusinessLayer.Interface;
using Common;
using Configuration;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApiService.Core.ApiControllers
{
    /// <summary>
    /// 信息日志管理-error
    /// </summary>
    public class ErrorLogController : ManagerController
    {
        public IErrorLogManager IErrorLogManager { get; set; }

        /// <summary>
        /// 查询平台
        /// </summary>
        /// <param name="query">查询条件</param>
        /// <returns></returns>
        [HttpGet]
        public AjaxReturnInfo Query([FromUri] LogQuery query)
        {
            var datas = IErrorLogManager.QueryLogInfo(query);
            return new AjaxReturnInfo()
            {
                Data = new
                {
                    List = datas,
                    query.Pagination,
                }
            };
        }
    }
}
