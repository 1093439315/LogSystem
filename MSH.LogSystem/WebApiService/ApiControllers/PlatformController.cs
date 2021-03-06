﻿using BusinessLayer.Interface;
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
    /// 平台管理服务
    /// </summary>
    public class PlatformController : ManagerController
    {
        public IPlatformManager IPlatformManager { get; set; }

        /// <summary>
        /// 查询平台
        /// </summary>
        /// <param name="query">查询条件</param>
        /// <returns></returns>
        [HttpGet]
        public AjaxReturnInfo Query([FromUri] PlatformQuery query)
        {
            var datas = IPlatformManager.QueryPlatform(query);
            return new AjaxReturnInfo()
            {
                Data = new
                {
                    List = datas,
                    query.Pagination,
                }
            };
        }

        /// <summary>
        /// 新增平台
        /// </summary>
        /// <param name="platform">平台</param>
        /// <returns></returns>
        [HttpPost]
        public AjaxReturnInfo Add(Platform platform)
        {
            IPlatformManager.AddPlatform(platform);
            return new AjaxReturnInfo();
        }

        /// <summary>
        /// 删除(可批量)
        /// </summary>
        /// <param name="ids">Id列表</param>
        /// <returns></returns>
        [HttpDelete]
        public AjaxReturnInfo Delete([FromUri] List<string> ids)
        {
            IPlatformManager.DeletePlatform(ids);
            return new AjaxReturnInfo();
        }
    }
}
