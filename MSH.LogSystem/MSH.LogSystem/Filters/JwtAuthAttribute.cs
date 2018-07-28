using Common;
using Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;

namespace MSH.LogSystem.Filters
{
    public class JwtAuthAttribute : AuthorizeAttribute
    {
        //private IDoctorManager IDoctorManager = new DoctorManager();
        //private IVerificationManager IVerificationManager = new VerificationManager();

        public override void OnAuthorization(HttpActionContext actionContext)
        {
            //标注AllowAnonymousAttribute时不做认证
            if (actionContext.ActionDescriptor.GetCustomAttributes<AllowAnonymousAttribute>().Any())
                return;

            var headers = actionContext.Request.Headers;

            //获取Header
            var authHeader = headers.FirstOrDefault(a => a.Key.ToLower().Equals(Constants.TokenName));//获取接收的Token

            if (headers == null || !headers.Any() || authHeader.Key == null || string.IsNullOrEmpty(authHeader.Value.FirstOrDefault()))
                throw new LoginFaildException("请求的Header中必须要有token信息！");

            //获取token
            var sendToken = authHeader.Value.FirstOrDefault();

            //当前时间戳
            var utcNowTime = DateTime.UtcNow;

            var dictPayload = JwtTokenHelper.Decode(sendToken);
            if (dictPayload == null)
                throw new LoginFaildException("token无效！");

            DateTime creatTime = dictPayload[Constants.ValidateFrom];
            DateTime expTime = dictPayload[Constants.ValidateTo];

            //检查令牌的有效期
            if (creatTime > utcNowTime || utcNowTime > expTime)
                throw new LoginFaildException("登录信息已过期！");

            string userName = dictPayload[Constants.UserName];
            //var user = IDoctorManager.QueryDoctorByCode(userName);

            //把toke用户数据放到 HttpContext.Current.User 里
            //if (HttpContext.Current != null)
            //    HttpContext.Current.User = new UserPrincipal(user)
            //    {
            //        Token = sendToken,
            //        Permissions = IVerificationManager.QueryUserObjectOperationPermission(user.Id),
            //    };

            base.OnAuthorization(actionContext);
        }
    }
}