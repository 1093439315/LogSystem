using BusinessLayer.Interface;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class UserManager : IUserManager
    {
        public User GetUserInfoByCode(string code)
        {
            return new User()
            {
                Code="hai.liu",
                Name="刘海",
                Id=1,
                Password="123"
            };
        }
    }
}
