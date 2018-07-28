using MSH.LogSystem.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MSH.LogSystem.Controllers
{
    /// <summary>
    /// 管理端控制器
    /// </summary>
    [JwtAuth]
    public class ManagerController : ApiController
    {
    }
}