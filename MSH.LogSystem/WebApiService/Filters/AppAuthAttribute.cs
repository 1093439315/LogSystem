using BusinessLayer;
using BusinessLayer.Interface;
using Common;
using Configuration;
using WebApiService.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Net.Http.Headers;

namespace WebApiService.Core
{
    public class AppAuthAttribute : AuthorizeAttribute
    {
        private IPlatformManager IPlatformManager = new PlatformManager();

        public override void OnAuthorization(HttpActionContext actionContext)
        {
            //标注AllowAnonymousAttribute时不做认证
            if (actionContext.ActionDescriptor.GetCustomAttributes<AllowAnonymousAttribute>().Any())
                return;

            base.OnAuthorization(actionContext);
        }

        protected override bool IsAuthorized(HttpActionContext actionContext)
        {
            var headers = actionContext.Request.Headers;

            var appId = GetHeader(headers,"AppId");
            var secrect = GetHeader(headers,"Secrect");

            //检验AppId和Secrect
            var platform = IPlatformManager.GetPlatformByAppSecrect(appId, secrect);
            if (platform == null)
                throw new LoginFaildException("AppId和Secrect不存在！");
            
            //保存当前请求的用户信息
            actionContext.RequestContext.Principal = new ClientPrincipal(platform)
            {
                AppId = platform.AppId,
            };

            return true;
        }

        protected override void HandleUnauthorizedRequest(HttpActionContext actionContext)
        {
            base.HandleUnauthorizedRequest(actionContext);
        }

        protected string GetHeader(HttpRequestHeaders headers, string key)
        {
            var header= headers.FirstOrDefault(a => a.Key.ToLower().Equals(key.ToLower()));

            if (headers == null || !headers.Any() || header.Key == null || string.IsNullOrEmpty(header.Value.FirstOrDefault()))
                throw new LoginFaildException("请求的Header中必须要有AppId和Secrect信息！");
            return header.Value.FirstOrDefault();
        }
    }
}