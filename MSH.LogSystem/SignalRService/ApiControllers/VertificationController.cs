using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BusinessLayer.Interface;
using Common;
using Configuration;
using DTO;

namespace WebApiService.ApiControllers
{
    /// <summary>
    /// 验证授权服务
    /// </summary>
    public class VertificationController : ManagerController
    {
        public IUserManager IUserManager { get; set; }

        /// <summary>
        /// 登录
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [AllowAnonymous]
        public AjaxReturnInfo Login([FromBody] LoginRequest loginModel)
        {
            if (loginModel == null) return new AjaxReturnInfo("用户名不能为空！");
            string userName = loginModel.UserName;
            string password = loginModel.Password;
            if (string.IsNullOrEmpty(userName))
                throw new LoginFaildException("用户名不能为空！");
            if (userName.Length > 20)
                throw new LoginFaildException("用户名的长度不能超过20！");
            if (string.IsNullOrEmpty(password))
                throw new LoginFaildException("密码不能为空！");
            var doc = IUserManager.GetUserInfoByCode(userName);
            if (doc == null)
                throw new LoginFaildException("用户不存在！");
            if (doc.Password != "123")
                throw new LoginFaildException("密码错误！");
            //if (password.EncryptToMD5() != doc.Password)
            //    throw new LoginFaildException("密码错误！");

            //生成Token
            Dictionary<string, dynamic> dic = new Dictionary<string, dynamic>();
            dic.Add(Constants.UserName, userName);
            var token = JwtTokenHelper.Generate(dic);
            return new AjaxReturnInfo()
            {
                Data = new
                {
                    UserInfo = doc,
                    Token = token,
                }
            };
        }
    }
}
