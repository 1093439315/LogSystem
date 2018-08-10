using WebApiService.Core.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApiService.Core.ApiControllers
{
    /// <summary>
    /// 管理端控制器、采用Token认证
    /// </summary>
    [JwtAuth]
    public class ManagerController : ApiController
    {
    }
}