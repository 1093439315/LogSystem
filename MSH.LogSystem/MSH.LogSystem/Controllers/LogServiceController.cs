﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using DTO;

namespace MSH.LogSystem.Controllers
{
    /// <summary>
    /// 日志服务
    /// </summary>
    public class LogServiceController : ApiController
    {
        /// <summary>
        /// 记录Info日志
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<AjaxReturnInfo> Info([FromBody] LogRequest request)
        {
            return await Task.Run(() =>
            {
                return new AjaxReturnInfo();
            });
        }
    }
}