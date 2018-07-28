using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace BusinessLayer.Interface
{
    /// <summary>
    /// 管理端用户管理
    /// </summary>
    public interface IUserManager : IDependency
    {
        /// <summary>
        /// 根据Code获取用户信息
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        User GetUserInfoByCode(string code);
    }
}