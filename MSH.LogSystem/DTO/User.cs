using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    /// <summary>
    /// 管理端用户
    /// </summary>
    public class User
    {
        public int Id { get; set; }
        /// <summary>
        /// 用户唯一标识
        /// </summary>
        public string Code { get; set; }
        /// <summary>
        /// 用户姓名
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 密码
        /// </summary>
        public string Password { get; set; }
    }
}
