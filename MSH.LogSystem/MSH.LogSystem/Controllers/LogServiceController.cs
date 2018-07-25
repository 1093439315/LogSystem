﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using BusinessLayer.Interface;
using DTO;

namespace MSH.LogSystem.Controllers
{
    /// <summary>
    /// 日志服务
    /// </summary>
    public class LogServiceController : ApiController
    {
        public ILogServiceManager LogServiceManager { get; set; }

        /// <summary>
        /// 记录Info日志
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<AjaxReturnInfo> Info([FromBody] LogRequest request)
        {
            return await Task.Run(() =>
            {
                LogServiceManager.SendInfoLog(request);
                return new AjaxReturnInfo();
            });
        }

        [HttpGet]
        public string Test()
        {
            return "Hello World";
        }
    }
}