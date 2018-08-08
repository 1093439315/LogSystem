using Common;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http.Filters;

namespace WebApiService.Filters
{
    public class HandleCustomExceptionAttribute : ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext filterContext)
        {
            var ex = filterContext.Exception;
            if (ex is LoginFaildException)
            {
                filterContext.Response = filterContext.Request.CreateResponse(HttpStatusCode.Unauthorized, new AjaxReturnInfo(ex.Message));
            }
            else if (ex is BaseCustomException)
            {
                filterContext.Response = filterContext.Request.CreateResponse(HttpStatusCode.NotImplemented, new AjaxReturnInfo(ex.Message));
            }
            else
                filterContext.Response = filterContext.Request.CreateResponse(HttpStatusCode.ServiceUnavailable, new AjaxReturnInfo(ex.Message));
            Logger.Error("请求地址:{0}  发生错误:{1}", filterContext.Request.RequestUri, ex);
            base.OnException(filterContext);
        }
    }
}